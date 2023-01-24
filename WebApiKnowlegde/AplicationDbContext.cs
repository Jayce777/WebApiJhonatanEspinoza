using Microsoft.EntityFrameworkCore;
using WebApiKnowlegde.Entidades;

namespace WebApiKnowlegde
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions options):base (options)
        {

        }

        public DbSet<entrerprises> entrerprises { get; set; }
        public DbSet<departaments> departaments { get; set; }
        public DbSet<employees> employees { get; set; }

    }
}
