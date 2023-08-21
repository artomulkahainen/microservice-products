using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Product> Products { get; set; } = null!;

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("numeric(18, 2)");
    }
}
