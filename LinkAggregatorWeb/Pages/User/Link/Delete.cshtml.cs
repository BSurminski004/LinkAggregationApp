using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User.Link
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        private IStatisticsRepository _StatisticsRepository { get; set; }
        public HyperLink HyperLink { get; set; }
        public DeleteModel(IHyperLinkRepository hyperLinkRepository, IStatisticsRepository statisticsRepository)
        {
            _HyperLinkRepository = hyperLinkRepository;
            _StatisticsRepository = statisticsRepository;
        }
        public void OnGet(int id)
        {
            HyperLink = _HyperLinkRepository.GetFirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var hyperlinkFromDb = _HyperLinkRepository.GetFirstOrDefault(u => u.Id ==HyperLink.Id);
            if (hyperlinkFromDb != null)
            {
                _HyperLinkRepository.Remove(hyperlinkFromDb);
                _HyperLinkRepository.Save();
                TempData["error"] = "URL deleted succesfully!";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
