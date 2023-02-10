using Microsoft.EntityFrameworkCore;
using WS_GYM.Models;

namespace WS_GYM.Data
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<Karnet> Karnety { get; set; }
        public DbSet<Zajecia> Zajecia { get; set;}
        public DbSet<ZajeciaUser> ZajeciaUser { get; set; }
    }
}
