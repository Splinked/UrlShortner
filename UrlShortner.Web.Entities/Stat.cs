using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortner.Web.Entities
{
    [Table("stats")]
    public class Stat
    {
        [Key] [Column("id")] public int Id { get; set; }

        [Required] [Column("click_date")] public DateTime ClickDate { get; set; }

        [Required]
        [Column("ip")]
        [StringLength(50)]
        public string Ip { get; set; }

        [Column("referer")]
        [StringLength(500)]
        public string Referer { get; set; }

        public ShortUrl ShortUrl { get; set; }
    }
}