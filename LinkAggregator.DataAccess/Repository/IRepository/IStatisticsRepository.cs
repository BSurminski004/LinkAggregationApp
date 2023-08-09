using LinkAggregation.Models;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IStatisticsRepository : IRepository<Statistic>
    {
        //void GetData(HttpClient httpClient, HyperLink hyperLink);
        void GetData(string ipAddress, HyperLink hyperlinkId);
        void BuildChart(Statistic statistic);
        void Save();
    }
}
