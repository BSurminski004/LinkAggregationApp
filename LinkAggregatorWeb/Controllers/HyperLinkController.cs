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
        private IStatisticsRepository _StatRepository { get; set; }

        public HyperLinkController(IHyperLinkRepository HyperLinkRepository, IStatisticsRepository statRepository)
        {
            _HyperLinkRepository = HyperLinkRepository;
            _StatRepository = statRepository;
        }

        [HttpGet("Redirect/{param}")]
        public IActionResult YtRedirect(string param)
        {
            //https://localhost:7282/url/Redirect/6^13^2023!11(00(00!PM0
            if (_HyperLinkRepository.GetAll().Any(e => e.HashCode == param))
            {
                var hyperLink = _HyperLinkRepository.GetFirstOrDefault(x => x.HashCode == param);
                //_StatRepository.GetData(Request.HttpContext, hyperLink);
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                return Redirect(hyperLink.Url);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
