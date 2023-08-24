using IPinfo;
using IPinfo.Models;
using LinkAggregation.Models;
using LinkAggregator.DataAccess.DBContext;
using LinkAggregator.DataAccess.Repository.IRepository;
using LinkAggregator.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinkAggregator.DataAccess.Repository
{
    public class StatisticsRepository : Repository<Statistic>, IStatisticsRepository
    {
        private readonly ApplicationDbContext _db;
        private IPinfoClient client;
        private IPResponse _ipResponse;
        public StatisticsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void AddStatistic(Statistic statistic)
        {
            _db.Statistic.Add(statistic);
        }

        public IEnumerable<Statistic> GetData()
        {
            var result = from st in _db.Statistic
                          select new Statistic
                          {
                              HyperLinkName = st.HyperLinkName,
                              IpNumber = st.IpNumber,
                              Localization = st.Localization,
                              DateVisit = st.DateVisit,
                              TimeVisit = st.TimeVisit,
                              Referrer = st.Referrer
                          };
            return result;
        }

        public IEnumerable<UrlVisitsData> BuildUrlVisitAmountsChart()
        {
            var result = from st in _db.Statistic
                         join hp in _db.HyperLink on st.HyperLinkId equals hp.Id
                         group st by hp.Name into g
                         orderby g.Count() descending
                         select new UrlVisitsData
                         {
                             Name = g.Key,
                             TotalVisits = g.Count()
                         };
            return result;
        }

        public IEnumerable<StatisticMonthlyVisitData> BuildMonthlyVisitChart()
        {
            var result = from st in _db.Statistic
                         group st by st.DateVisit into g
                         orderby g.Count() descending
                         select new StatisticMonthlyVisitData
                         {
                             DateVisit = g.Key,
                             TotalVisits = g.Count()
                         };

            return result;
        }


        public IEnumerable<LocalizationData> BuildLocalizationChart()
        {
            var result = from st in _db.Statistic
                         group st by st.Localization into g
                         orderby g.Count() descending
                         select new LocalizationData
                         {
                             Localization = g.Key,
                             TotalVisits = g.Count()
                         };
            return result;
        }

        public IEnumerable<IpAddressesData> BuildMostActiveIpAddressesChart()
        {
            var result = from st in _db.Statistic
                         group st by st.IpNumber into g
                         orderby g.Count() descending
                         select new IpAddressesData
                         {
                             IpAddress = g.Key,
                             TotalVisits = g.Count()
                         };

            return result;
        }

        public void CreateStatistic(string ipAddress, string referer, HyperLink hyperlink)
        {
            string token = "cb9f4bdbf77f37";
            client = new IPinfoClient.Builder()
                .AccessToken(token)
                .Build();
            _ipResponse = client.IPApi.GetDetails(ipAddress);

            this.AddStatistic(new Statistic()
            {
                HyperLinkName = hyperlink.Name,
                Referrer = referer,
                IpNumber = ipAddress,
                DateVisit = DateTime.Now.ToString("dd-MM-yyyy"),
                TimeVisit = DateTime.Now.ToString("HH:mm"),
                Hyperlink = hyperlink,
                HyperLinkId = hyperlink.Id,
                Localization = _ipResponse.CountryName
            });
            this.Save();     
        }

        public void Save()
        {
            _db.SaveChanges();
        }

       
    }
}
