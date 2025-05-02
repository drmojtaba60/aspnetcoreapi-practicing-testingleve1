namespace MyTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MyTest.Domain.Entities;
public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // کانفیگ Entityها
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.OwnsOne(e => e.Address); // اگر Address Value Object باشه
        });

        base.OnModelCreating(modelBuilder);
    }
}
