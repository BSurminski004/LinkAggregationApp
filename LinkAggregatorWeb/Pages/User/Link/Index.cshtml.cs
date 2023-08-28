using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User.Link
{
    public class IndexModel : PageModel
    {
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public IEnumerable<HyperLink> HyperLinks { get; set; }

        public IndexModel(IHyperLinkRepository hyperLinkRepository)
        {
            _HyperLinkRepository = hyperLinkRepository;
        }

        public async void OnGetAsync(string sortOrder, string searchString)
        {
            HyperLinks = _HyperLinkRepository.GetAll().OrderByDescending(x => x.Id);
            _HyperLinkRepository.IsValidHyperLinks(HyperLinks);

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            CurrentSort = sortOrder;
            CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                HyperLinks = HyperLinks.Where(s => s.Name.Contains(searchString.ToLower()) ||
                s.Url.Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    HyperLinks = HyperLinks.OrderByDescending(s => s.Name);
                    break;
                case "date_asc":
                    HyperLinks = HyperLinks.OrderBy(s => s.ValidTo);
                    break;
                case "date_desc":
                    HyperLinks = HyperLinks.OrderByDescending(s => s.ValidTo);
                    break;
                default:
                    HyperLinks = HyperLinks.OrderBy(s => s.Name);
                    break;
            }
        }
    }
}
