using System.Threading.Tasks;
using System.Web.Mvc;
using UrlShortner.Models;
using UrlShortner.Web.Business;
using UrlShortner.Web.Entities;

namespace UrlShortner.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlManager;

        public UrlController(IUrlManager urlManager)
        {
            _urlManager = urlManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Url url = new Url();
            return View(url);
        }

        public async Task<ActionResult> Index(Url url)
        {
            if (ModelState.IsValid)
            {
                ShortUrl shortUrl = await this._urlManager.ShortenUrl(url.LongUrl, Request.UserHostAddress, url.CustomSegment);
                url.ShortUrl = string.Format("{0}://{1}{2}{3}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"), shortUrl.Segment);
            }
            return View(url);
        }

        public async Task<ActionResult> Click(string segment)
        {
            string referer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            Stat stat = await this._urlManager.Click(segment, referer, Request.UserHostAddress);
            return this.RedirectPermanent(stat.ShortUrl.LongUrl);
        }
    }
}