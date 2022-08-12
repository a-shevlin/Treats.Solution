using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Treats.Models
{
  public class TreatsContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Flavor> Flavors {get; set;}
    public DbSet<Treat> Treats {get; set;}
    public DbSet<TreatFlavors> TreatFlavors {get; set;}

    public TreatsContext (DbContextOptions options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}