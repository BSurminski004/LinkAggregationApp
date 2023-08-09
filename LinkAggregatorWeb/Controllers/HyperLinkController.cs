using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LinkAggregator.DataAccess.Repository.IRepository;
using LinkAggregator.DataAccess.Repository;
using LinkAggregatorWeb.Services;

namespace LinkAggregatorWeb.Controllers
{
    //[Route("url")]
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

        [HttpGet("{param}")]
        public IActionResult YtRedirect(string param)
        {
            if (_HyperLinkRepository.GetAll().Any(e => e.HashCode == param))
            {
                var hyperLink = _HyperLinkRepository.GetFirstOrDefault(x => x.HashCode == param);
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                _StatRepository.GetData(ipAddress, hyperLink);
                return Redirect(URLsChecker.CheckURL(hyperLink.Url));
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
