using FoodFiestaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFiestaApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<History> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship between Food and Ingredient
            modelBuilder.Entity<Food>()
                .HasMany(f => f.Ingredients)
                .WithOne(i => i.Food)
                .HasForeignKey(i => i.FoodId);

            // Configure one-to-many relationship between Customer and Comment
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            // Configure many-to-many relationship between Customer and Food through History
            modelBuilder.Entity<History>()
                .HasKey(h => new { h.CustomerId, h.FoodId });

            modelBuilder.Entity<History>()
                .HasOne(h => h.Customer)
                .WithMany(c => c.History)
                .HasForeignKey(h => h.CustomerId);

            modelBuilder.Entity<History>()
                .HasOne(h => h.Food)
                .WithMany(f => f.History)
                .HasForeignKey(h => h.FoodId);

            // Configure many-to-many relationship between Customer and Food through Cart
            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.CustomerId, c.FoodId });

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Cart)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Food)
                .WithMany(f => f.Cart)
                .HasForeignKey(c => c.FoodId);
        }


    }
}
