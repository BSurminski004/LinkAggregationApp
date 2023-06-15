using LinkAggregation.Models;
using LinkAggregator.DataAccess.DBContext;
using LinkAggregator.DataAccess.Repository.IRepository;

namespace LinkAggregator.DataAccess.Repository
{
    public class StatisticsRepository : Repository<Statistic>, IStatisticsRepository
    {
        private readonly ApplicationDbContext _db;
        public StatisticsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void GetData(HttpClient httpClient, HyperLink hyperLink)
        {
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
