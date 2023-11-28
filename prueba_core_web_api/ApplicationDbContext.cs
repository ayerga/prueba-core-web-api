using Microsoft.EntityFrameworkCore;
using prueba_core_web_api;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(
                "User Id=C##_ABAU;Password=ABAU;Data Source=192.168.104.208:1521/orcl");
        }
        public DbSet<ART_AFFILIATIONs> ART_AFFILIATION { get; set; }
        public DbSet<ART_BIND_AFFILIATION_DEVICEs> ART_BIND_AFFILIATION_DEVICE { get; set; }

    }
}