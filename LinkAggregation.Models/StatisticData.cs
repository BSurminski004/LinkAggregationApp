namespace LinkAggregator.Models
{
    public class UrlVisitsData
    {
        public string Name { get; set; }
        public int TotalVisits { get; set; }
    }

    public class StatisticMonthlyVisitData
    {
        public string DateVisit { get; set; }
        public int TotalVisits { get; set; }
    }

    public class IpAddressesData
    {
        public string IpAddress { get; set; }
        public int TotalVisits { get; set; }
    }

    public class LocalizationData
    {
        public string Localization { get; set; }
        public int TotalVisits { get; set; }
    }

}
