using Microsoft.EntityFrameworkCore;
using Shop.Api.Models;


namespace Shop.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Code)
            .IsUnique();
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }


}