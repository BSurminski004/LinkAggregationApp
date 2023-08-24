using LinkAggregation.Models;
using LinkAggregator.Models;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IStatisticsRepository : IRepository<Statistic>
    {
        void CreateStatistic(string ipAddress, string referer, HyperLink hyperLink);
        void AddStatistic(Statistic statistic);
        IEnumerable<Statistic> GetData();
        IEnumerable<UrlVisitsData> BuildUrlVisitAmountsChart();
        IEnumerable<IpAddressesData> BuildMostActiveIpAddressesChart();
        IEnumerable<LocalizationData> BuildLocalizationChart();
        IEnumerable<StatisticMonthlyVisitData> BuildMonthlyVisitChart();
        void Save();
    }
}
