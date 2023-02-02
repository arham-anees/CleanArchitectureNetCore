using CleanArchitectureNetCore.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.EfMariaDb
{
  public class MariaDbContext:DbContext
  {
    public DbSet<User> Users { get; set; }
    
    public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
