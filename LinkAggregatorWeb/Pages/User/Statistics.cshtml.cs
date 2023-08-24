using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using LinkAggregator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LinkAggregatorWeb.Pages.User
{
    public class StatisticsModel : PageModel
    {
        private IStatisticsRepository _statisticRepository;
        public string urlVisitAmountsJson { get; set; }
        public string mostActiveIpAddressesJson { get; set; }
        public string allLocalizalizationsJson { get; set; }
        public string monthlyVisitsJson { get; set; }
        public IEnumerable<Statistic> Statistics { get; set; }

        public StatisticsModel(IStatisticsRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async void OnGetAsync()
        {
            Statistics = _statisticRepository.GetData().OrderByDescending(x => x.DateVisit);

            urlVisitAmountsJson = JsonSerializer.Serialize(_statisticRepository.BuildUrlVisitAmountsChart());
            mostActiveIpAddressesJson = JsonSerializer.Serialize(_statisticRepository.BuildMostActiveIpAddressesChart());
            allLocalizalizationsJson = JsonSerializer.Serialize(_statisticRepository.BuildLocalizationChart());
            monthlyVisitsJson = JsonSerializer.Serialize(_statisticRepository.BuildMonthlyVisitChart());
        }
    }
}
