using Microsoft.EntityFrameworkCore;
using WS_GYM.Models;

namespace WS_GYM.Data
{
    public class FitnessContext : DbContext
    {
        public FitnessContext()
        {

        }

        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public virtual DbSet<Karnet> Karnety { get; set; }
        public virtual DbSet<Zajecia> Zajecia { get; set;}
        public virtual DbSet<ZajeciaUser> ZajeciaUser { get; set; }
    }
}
