using System;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Web.Data;
using UrlShortner.Web.Entities;
using UrlShortner.Web.Exceptions;

namespace UrlShortner.Web.Business.Impl
{
    public class UrlManager : IUrlManager
    {
        public Task<ShortUrl> ShortenUrl(string longUrl, string ip, string segment = "")
        {
            return Task.Run(() =>
            {
                using (var ctx = new UrlShortnerContext())
                {
                    ShortUrl url;

                    url = ctx.ShortUrls.Where(u => u.LongUrl == longUrl).FirstOrDefault();
                    if (url != null)
                    {
                        return url;
                    }

                    if (!string.IsNullOrEmpty(segment))
                    {
                        if (ctx.ShortUrls.Where(u => u.Segment == segment).Any())
                        {
                            throw new UrlShortnerConflictException();
                        }
                    }
                    else
                    {
                        segment = this.NewSegment();
                    }

                    if (string.IsNullOrEmpty(segment))
                    {
                        throw new ArgumentException("Segment is empty");
                    }

                    url = new ShortUrl()
                    {
                        Added = DateTime.Now,
                        Ip = ip,
                        LongUrl = longUrl,
                        NumOfClicks = 0,
                        Segment = segment
                    };

                    ctx.ShortUrls.Add(url);

                    ctx.SaveChanges();

                    return url;
                }
            });
        }

        public Task<Stat> Click(string segment, string referer, string ip)
        {
            return Task.Run(() =>
            {
                using (var ctx = new UrlShortnerContext())
                {
                    ShortUrl url = ctx.ShortUrls.Where(u => u.Segment == segment).FirstOrDefault();
                    if (url == null)
                    {
                        throw new UrlShortnerNotFoundException();
                    }

                    url.NumOfClicks = url.NumOfClicks + 1;

                    Stat stat = new Stat()
                    {
                        ClickDate = DateTime.Now,
                        Ip = ip,
                        Referer = referer,
                        ShortUrl = url
                    };

                    ctx.Stats.Add(stat);

                    ctx.SaveChanges();

                    return stat;
                }
            });
        }

        private string NewSegment()
        {
            using (var ctx = new UrlShortnerContext())
            {
                int i = 0;
                while (true)
                {
                    string segment = Guid.NewGuid().ToString().Substring(0, 6);
                    if (!ctx.ShortUrls.Where(u => u.Segment == segment).Any())
                    {
                        return segment;
                    }

                    if (i > 30)
                    {
                        break;
                    }

                    i++;
                }

                return string.Empty;
            }
        }
    }
}