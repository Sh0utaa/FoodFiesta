using FoodFiestaApp.Data;
using FoodFiestaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFiestaWebsite.Data;

public class FoodFiestaWebsiteDBContext : DbContext
{
    public FoodFiestaWebsiteDBContext(DbContextOptions<FoodFiestaWebsiteDBContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
