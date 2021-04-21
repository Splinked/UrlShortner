using MySql.Data.EntityFramework;
using System.Data.Entity;
using UrlShortner.Web.Entities;

namespace UrlShortner.Web.Data
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UrlShortnerContext : DbContext
    {
        public UrlShortnerContext()
            : base("name=UrlShortnerDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stat>()
                .HasRequired(s => s.ShortUrl)
                .WithMany(u => u.Stats)
                .Map(m => m.MapKey("shortUrl_id"));
        }

        public virtual DbSet<ShortUrl> ShortUrls { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
    }
}