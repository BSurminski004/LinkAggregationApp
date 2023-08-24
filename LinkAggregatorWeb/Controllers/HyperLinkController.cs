using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LinkAggregator.DataAccess.Repository.IRepository;
using LinkAggregator.DataAccess.Repository;
using LinkAggregatorWeb.Services;
using LinkAggregation.Models;
using IPinfo;

namespace LinkAggregatorWeb.Controllers
{
    [ApiController]
    public class HyperLinkController : Controller
    {
        private IHyperLinkRepository _hyperLinkRepository { get; set; }
        private IStatisticsRepository _statRepository { get; set; }
        public Statistic Statistic { get; set; }

        public HyperLinkController(IHyperLinkRepository HyperLinkRepository, IStatisticsRepository statRepository)
        {
            _hyperLinkRepository = HyperLinkRepository;
            _statRepository = statRepository;
        }

        [HttpGet("{param}")]
        public IActionResult GetRedirect(string param)
        {
            if (_hyperLinkRepository.GetAll().Any(e => e.HashCode == param))
            {
                HyperLink hyperLink = _hyperLinkRepository.GetFirstOrDefault(x => x.HashCode == param);
                if (!hyperLink.IsValid) { goto NotFoundOrNotAvailable; }

                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                string referer = Request.HttpContext.Request.Headers["Referer"].ToString();

                _statRepository.CreateStatistic(ipAddress, referer, hyperLink);
                return Redirect(URLsChecker.CheckURL(hyperLink.Url));
            }
            else { goto NotFoundOrNotAvailable; }

        NotFoundOrNotAvailable:
            return Redirect("https://localhost:7282/NotFound");
        }
    }
}
