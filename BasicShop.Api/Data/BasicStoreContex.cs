namespace BasicShop.Api.Data;

using BasicShop.Api.Enum;
using BasicShop.Api.Models;
using Microsoft.EntityFrameworkCore;

public class BasicStoreContext(DbContextOptions<BasicStoreContext> options) : DbContext(options)
{

    public DbSet<Item> Items => Set<Item>();
    public DbSet<Cart> Cart => Set<Cart>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
        new { Id = 1, Name = "Apple", Description = "Red fruit", Price = 12.50m, Quantity = 3, Category = Category.Fruits },
        new { Id = 2, Name = "Red car", Description = "Red BWM", Price = 120000.50m, Quantity = 1, Category = Category.Cars }
        );
    }
}
