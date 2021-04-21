using System.Web.Mvc;
using UrlShortner.Filters;

namespace UrlShortner
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UrlShortnerExceptionFilter());
        }
    }
}