using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiKnowlegde.Entidades;

namespace WebApiKnowlegde
{
    public class AplicationDbContext: IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<departaments_employees>()
                .HasKey(de => new { de.departamentsId, de.employeesId });
        }

        public DbSet<entrerprises> entrerprises { get; set; }
        public DbSet<departaments> departaments { get; set; }
        public DbSet<employees> employees { get; set; }
        public DbSet<departaments_employees> departaments_employees { get; set; }

    }
}
