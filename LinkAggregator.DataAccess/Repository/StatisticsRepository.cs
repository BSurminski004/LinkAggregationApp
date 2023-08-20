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
        public void GetData(string ipAddress, string referer, HyperLink hyperLink)
        {
            Statistic stat1 = new Statistic()
            {
                IpNumber = ipAddress,
                HyperLinkId = hyperLink.Id,
                DateVisit = DateTime.Now.ToString("dd-MM-yyyy"),
                TimeVisit = DateTime.Now.ToString("HH-mm"),
                Hyperlink = hyperLink
            }; 

            _db.Statistic.Add(stat1);
        }

        public void BuildChart(Statistic statistic)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

       
    }
}
