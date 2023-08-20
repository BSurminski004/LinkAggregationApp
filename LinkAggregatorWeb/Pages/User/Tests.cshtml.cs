using LinkAggregation.Models;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages.User
{
    public class TestsModel : PageModel
    {
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        private IHyperLinkRepository _HyperLinkRepository { get; set; }
        public IEnumerable<HyperLink> HyperLinks { get; set; }

        public TestsModel(IHyperLinkRepository hyperLinkRepository)
        {
            _HyperLinkRepository = hyperLinkRepository;
        }

        public async void OnGetAsync(string sortOrder, string searchString)
        {

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "date_asc";

            CurrentFilter = searchString;

            HyperLinks = _HyperLinkRepository.GetAll().OrderByDescending(x => x.Id);

            if (!String.IsNullOrEmpty(searchString))
            {
                HyperLinks = HyperLinks.Where(s => s.Name.Contains(searchString.ToLower()) || 
                s.Url.Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    HyperLinks = HyperLinks.OrderByDescending(s => s.Name);
                    break;
                case "date_asc":
                    HyperLinks = HyperLinks.OrderBy(s => s.ValidFrom);
                    break;
                case "date_desc":
                    HyperLinks = HyperLinks.OrderByDescending(s => s.ValidFrom);
                    break;
                default:
                    HyperLinks = HyperLinks.OrderBy(s => s.Name);
                    break;
            }
        }
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