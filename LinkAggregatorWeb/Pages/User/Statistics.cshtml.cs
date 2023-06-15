using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User
{
    public class StatisticsModel : PageModel
    {
        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public IEnumerable<HyperLink> HyperLinks { get; set; }
        public string[] labels;
        public StatisticsModel(IHyperLinkRepository hyperLinkRepository)
        {
            _HyperLinkRepository = hyperLinkRepository;
        }
        public void OnGet()
        {
            HyperLinks = _HyperLinkRepository.GetAll();
            labels = HyperLinks.Select(x => x.Name).ToArray();
            string labelsFinish = string.Join(",", labels);
            ViewData["Labels"] = string.Join(",", labels);
        }
    }
}
