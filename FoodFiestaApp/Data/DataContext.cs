using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here

            // Configure Cart
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cart)
                .HasForeignKey(c => c.userId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Food)
                .WithMany()
                .HasForeignKey(c => c.FoodId);

            // Configure Comment
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.userId);

            // Configure Food
            modelBuilder.Entity<Food>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Food>()
                .HasMany(f => f.Cart)
                .WithOne(c => c.Food)
                .HasForeignKey(c => c.FoodId);

            modelBuilder.Entity<Food>()
                .HasMany(f => f.FoodIngredientTable)
                .WithOne(fi => fi.Food)
                .HasForeignKey(fi => fi.FoodId);

            // Configure FoodIngredient
            modelBuilder.Entity<FoodIngredient>()
                .HasKey(fi => fi.Id);

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(fi => fi.Food)
                .WithMany(f => f.FoodIngredientTable)
                .HasForeignKey(fi => fi.FoodId);

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(fi => fi.Ingredient)
                .WithMany(i => i.FoodIngredientTable)
                .HasForeignKey(fi => fi.IngredientId);

            // Configure Ingredient
            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.Id);

            // Configure User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.userId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.userId);

            // Any additional configurations can be added here
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, IngredientName = "Salt" },
                new Ingredient { Id = 2, IngredientName = "Pepper" }
                // Add more ingredients as needed
            );

            // Seed foods
            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, FoodName = "Pizza", Price = 10.99, FoodImgUrl = "pizza.jpg" },
                new Food { Id = 2, FoodName = "Burger", Price = 8.99, FoodImgUrl = "burger.jpg" }
                // Add more foods as needed
            );

            // Seed food ingredients
            modelBuilder.Entity<FoodIngredient>().HasData(
                new FoodIngredient { Id = 1, FoodId = 1, IngredientId = 1 },
                new FoodIngredient { Id = 2, FoodId = 1, IngredientId = 2 }
                // Associate ingredients with foods
            );

            // Seed users first
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "User1", PasswordHash = null, PasswordSalt = null },
                new User { Id = 2, Username = "User2", PasswordHash = null, PasswordSalt = null }
            );

            // Seed comments after users
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, userId = 1, Text = "Delicious pizza!", Rating = 4.5, Datetime = DateTime.Now },
                new Comment { Id = 2, userId = 2, Text = "Great burger!", Rating = 5.0, Datetime = DateTime.Now }
            );


            // Seed carts
            modelBuilder.Entity<Cart>().HasData(
                new Cart { Id = 1, userId = 1, FoodId = 1 },
                new Cart { Id = 2, userId = 2, FoodId = 2 }
                // Add more carts as needed
            );

            // Add more seeding logic for other entities as needed
        }
    }
}
