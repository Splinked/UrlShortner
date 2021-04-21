using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Models
{
    public class Url
    {
        [Required]
        public string LongUrl { get; set; }

        public string ShortUrl { get; set; }

        public string CustomSegment { get; set; }
    }
}