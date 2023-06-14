using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LinkAggregator.DataAccess.Repository.IRepository;
using LinkAggregator.DataAccess.Repository;

namespace LinkAggregatorWeb.Controllers
{
    [Route("url")]
    [ApiController]
    public class HyperLinkController : Controller
    {
        private IHyperLinkRepository _HyperLinkRepository { get; set; }

        public HyperLinkController(IHyperLinkRepository HyperLinkRepository)
        {
            _HyperLinkRepository = HyperLinkRepository;
        }

        [HttpGet("Redirect/{param}")]
        public IActionResult YtRedirect(string param)
        {
            //https://localhost:7282/url/Redirect/6^13^2023!11(00(00!PM0
            if (_HyperLinkRepository.GetAll().Any(e => e.HashCode == param))
            {
                string url = _HyperLinkRepository.GetFirstOrDefault(x => x.HashCode == param).Url;
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                return Redirect(url);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
