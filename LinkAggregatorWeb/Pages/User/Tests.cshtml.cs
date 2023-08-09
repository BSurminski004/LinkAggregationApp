using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;



namespace LinkAggregatorWeb.Pages.User
{
    public class TestsModel : PageModel
    {
        public List<UrlData> UrlData { get; set; }
        public List<IpData> IpData { get; set; }

        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public IEnumerable<HyperLink> HyperLinks { get; set; }
        public string[] hyperlinksName { get; set; }
        public int[] hyperlinksIDs { get; set; }
        public TestsModel(IHyperLinkRepository hyperLinkRepository)
        {
            _HyperLinkRepository = hyperLinkRepository;
        }
 
        public void OnGet()
        {
            // Przykładowe dane URL
            UrlData = new List<UrlData>
            {
                new UrlData { Url = "abcd", Visits = 100 },
                new UrlData { Url = "efgh", Visits = 50 },
                new UrlData { Url = "scsfa", Visits = 75 }
            };

            // Przykładowe dane IP
            IpData = new List<IpData>
            {
                new IpData { IpAddress = "192.168.1.1", Country = "USA" },
                new IpData { IpAddress = "10.0.0.1", Country = "Canada" },
                new IpData { IpAddress = "172.16.0.1", Country = "UK" }
            };

            string[] arrayToPaste = new string[] { "Red", "Blue", "Yellow", "Green", "Purple", "Orange", "Adam", "abcdefg" };
            string[] hyperlinksName = new string[] { "abcd", "efgh", "scsfa"};

            var data = string.Join(", ", UrlData.Select(d => "'" + d.Url + "'"));
            var labels = string.Join(", ", UrlData.Select(d => d.Visits));


           
        }
    }


    public class IpData
    {
        public string IpAddress { get; set; }
        public string Country { get; set; }
    }

    public class UrlData
    {
        public string Url { get; set; }
        public int Visits { get; set; }
    }
}

////metody do pobierania lokalizacji z IP
//string ipAddress = "8.8.8.8"; // Przykładowy adres IP do odczytania lokalizacji
//var locationData = await GetLocationFromIp(ipAddress);

//Console.WriteLine("IP Address: " + locationData.Ip);
//Console.WriteLine("City: " + locationData.City);
//Console.WriteLine("Region: " + locationData.Region);
//Console.WriteLine("Country: " + locationData.Country);
//Console.WriteLine("Location: " + locationData.Location);

//    public class LocationData
//{
//    public string Ip { get; set; }
//    public string City { get; set; }
//    public string Region { get; set; }
//    public string Country { get; set; }
//    public string Location { get; set; }
//}

// static async Task<LocationData> GetLocationFromIp(string ipAddress)
//{
//    using (var httpClient = new HttpClient())
//    {
//        string url = $"http://ipinfo.io/{ipAddress}/json";
//        var response = await httpClient.GetStringAsync(url);
//        return System.Text.Json.JsonSerializer.Deserialize<LocationData>(response);
//    }
//}