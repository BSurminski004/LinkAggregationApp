using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LinkAggregatorWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HyperLinkController : Controller
    {
        [HttpGet("YtRedirect")]
        public IActionResult YtRedirect()
        {

            string youtubeUrl = "https://www.youtube.com/";

            // Przekierowanie na stronę YouTube
            return Redirect(youtubeUrl);
        }

        [HttpGet("RedUrl")]
        public IActionResult RedUrl(string hashCode)
        {
            try
            {
                var headers = Request.Headers;
                string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch (Exception e)
            {
                string m = e.Message;
            }
            //var headers = Request.Headers;
            //string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            string youtubeUrl = $"https://www.youtube.com/watch?v={hashCode}";
            // Przekierowanie na stronę YouTube
            return Redirect(youtubeUrl);
        }
        //public IActionResult YoutubeRedirect()
        //{
        //    // Tworzenie URL przekierowania na YouTube
            
        //}


    }
}
