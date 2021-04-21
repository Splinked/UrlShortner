using System.Threading.Tasks;
using UrlShortner.Web.Entities;

namespace UrlShortner.Web.Business
{
    public interface IUrlManager
    {
        Task<ShortUrl> ShortenUrl(string longUrl, string ip, string segment = "");

        Task<Stat> Click(string segment, string referer, string ip);
    }
}