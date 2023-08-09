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
            if (HyperLink.ValidFrom >= HyperLink.ValidTo)
            {
                ModelState.AddModelError("Hyperlink.ValidFrom", "Minimum validation time is 24h!");
            }

            if (_HyperLinkRepository.GetAll().FirstOrDefault(x => x.Url == HyperLink.Url) != null)
            {
                ModelState.AddModelError("Hyperlink.Url", "That URL already exists!\n");
                TempData["failed"] = "Thats URL already exists!";
            }

            if (_HyperLinkRepository.GetAll().FirstOrDefault(x => x.HashCode == HyperLink.HashCode) != null)
            {
                ModelState.AddModelError("Hyperlink.HashCode", "That Hashcode already exists!\n");
                TempData["failed"] = "Thats Hashcode already exists!";
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
