using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User.Link
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public HyperLink HyperLink { get; set; }
        public string locHost { get; set; }
        public EditModel(IHyperLinkRepository HyperLinkRepository)
        {
            _HyperLinkRepository = HyperLinkRepository;
        }
        public void OnGet(int id)
        {
            HyperLink = _HyperLinkRepository.GetFirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (HyperLink.ValidFrom == HyperLink.ValidTo)
            {
                ModelState.AddModelError("Hyperlink.ValidFrom", "\n Minimum validation time is 24h!\n");
            }
            if (_HyperLinkRepository.GetAll().FirstOrDefault(x => x.Url == HyperLink.Url) != null)
            {
                ModelState.AddModelError("Hyperlink.Url", "\n Thats URL already exists!\n");
                TempData["failed"] = "Thats URL already exists!";
            }

            if (ModelState.IsValid)
            {
                _HyperLinkRepository.Update(HyperLink);
                _HyperLinkRepository.Save();
                TempData["info"] = "URL updated succesfully!";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
