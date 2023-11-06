using Microsoft.EntityFrameworkCore;
using VinylStore.Domain.Entities;

namespace VinylStore.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql()
            .UseSnakeCaseNamingConvention();

        base.OnConfiguring(optionsBuilder);
    }

    // TODO: Consider using dedicated entities on the infra side to define the db structure and separate that from the domain.
    public DbSet<Customer> Customers { get; set; } = null!;
}