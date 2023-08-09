using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User.Link
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public HyperLink HyperLink { get; set; }
        public CreateModel(IHyperLinkRepository HyperLinkRepository)
        {
            _HyperLinkRepository = HyperLinkRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (HyperLink.ValidFrom >= HyperLink.ValidTo)
            {
                ModelState.AddModelError("Hyperlink.ValidFrom", " Wrong Validation Date!");
            }
            if (_HyperLinkRepository.GetAll().FirstOrDefault(x => x.Url == HyperLink.Url) != null)
            {
                ModelState.AddModelError("Hyperlink.Url", "\n Thats URL already exists!\n");
                TempData["failed"] = "Thats URL already exists!";
            }

            if (_HyperLinkRepository.GetAll().FirstOrDefault(x => x.HashCode == HyperLink.HashCode) != null)
            {
                ModelState.AddModelError("Hyperlink.HashCode", "That Hashcode already exists!\n");
                TempData["failed"] = "Thats Hashcode already exists!";
            }

            //HyperLink.HashCode = _HyperLinkRepository.RenderHashCode(HyperLink);

            if (ModelState.IsValid)
            {
                _HyperLinkRepository.Add(HyperLink);
                _HyperLinkRepository.Save();
                TempData["success"] = "New URL created succesfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
