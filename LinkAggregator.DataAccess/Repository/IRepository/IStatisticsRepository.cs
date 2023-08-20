using LinkAggregation.Models;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IStatisticsRepository : IRepository<Statistic>
    {
        void GetData(string ipAddress, string referer, HyperLink hyperlinkId);
        void BuildChart(Statistic statistic);
        void Save();
    }
}
