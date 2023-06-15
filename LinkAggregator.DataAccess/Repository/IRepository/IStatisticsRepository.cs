using LinkAggregation.Models;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IStatisticsRepository : IRepository<Statistic>
    {
        void GetData(HttpClient httpClient, HyperLink hyperLink);
        void Save();
    }
}
