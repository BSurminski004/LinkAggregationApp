using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User.Link
{
    public class IndexModel : PageModel
    {
        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public IEnumerable<HyperLink> HyperLinks { get; set; }
        public IndexModel(IHyperLinkRepository HyperLinkRepository)
        {
            _HyperLinkRepository = HyperLinkRepository;
        }
        public void OnGet()
        {
            HyperLinks = _HyperLinkRepository.GetAll().OrderByDescending(x => x.Id);
        }
    }
}
