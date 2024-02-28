using FoodFiestaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFiestaApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here

            // Example: User-Comment relationship
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.userId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

            // Example: Cart-User, Cart-Food, and Cart-Drink relationships
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cart)
                .HasForeignKey(c => c.userId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Food)
                .WithMany(f => f.Cart)
                .HasForeignKey(c => c.FoodId)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData(modelBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "User1", Email = "user1@example.com", Admin = false },
                new User { Id = 2, Username = "User2", Email = "user2@example.com", Admin = false }
                // Add more users as needed
            );

            // Seed Foods
            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, FoodName = "Pizza", Price = 10.99},
                new Food { Id = 2, FoodName = "Pasta", Price = 10.99 },
                new Food { Id = 3, FoodName = "Burger", Price = 10.99 },
                new Food { Id = 4, FoodName = "Steak", Price = 10.99 },
                new Food { Id = 5, FoodName = "Ramen", Price = 10.99 },
                new Food { Id = 6, FoodName = "Shawarma", Price = 10.99 },
                new Food { Id = 7, FoodName = "Sushi", Price = 10.99 },
                new Food { Id = 8, FoodName = "Cheesecake", Price = 10.99 },
                new Food { Id = 9, FoodName = "Ceasar Salad", Price = 10.99 },
                new Food { Id = 10, FoodName = "Mwvadi", Price = 10.99 }
                // Add more foods as needed
            );

            // Seed Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, userId = 1, Text = "Comment from User1", Rating = 4.5, Datetime = DateTime.Now },
                new Comment { Id = 2, userId = 2, Text = "Comment from User2", Rating = 3.0, Datetime = DateTime.Now }
                // Add more comments as needed
            );

            // Seed Cart
            modelBuilder.Entity<Cart>().HasData(
                new Cart { Id = 1, userId = 1, FoodId = 1},
                new Cart { Id = 2, userId = 2, FoodId = 2}
                // Add more cart items as needed
            );
        }
    }
}
