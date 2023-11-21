using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodFiestaApp.Data
{
    public class DataContext<TContext> : IdentityDbContext<Customer> where TContext : DbContext
    {
        public DataContext(DbContextOptions<TContext> options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Cart)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Food)
                .WithMany(f => f.Cart)
                .HasForeignKey(c => c.FoodId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Comments)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Food>()
                .HasMany(f => f.Cart)
                .WithOne(c => c.Food)
                .HasForeignKey(c => c.FoodId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Food>()
                .HasMany(f => f.FoodIngredientTable)
                .WithOne(fi => fi.Food)
                .HasForeignKey(fi => fi.FoodId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(fi => fi.Food)
                .WithMany(f => f.FoodIngredientTable)
                .HasForeignKey(fi => fi.FoodId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(fi => fi.Ingredient)
                .WithMany(i => i.FoodIngredientTable)
                .HasForeignKey(fi => fi.IngredientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.FoodIngredientTable)
                .WithOne(fi => fi.Ingredient)
                .HasForeignKey(fi => fi.IngredientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            //Seed customers
            //var customers = new List<Customer>
            //{
            //    new Customer { Id = "1", FirstName = "John", LastName = "Doe", UserName = "JohnDoe_27", Email = "john.doe@example.com" },
            //    new Customer { Id = "2", FirstName = "Jane", LastName = "Smith", UserName = "JaneSmith_07", Email = "jane.smith@example.com" },
            //     Add more customers as needed
            //};

            //modelBuilder.Entity<Customer>().HasData(customers);

            //Seed comments
            //var comments = new List<Comment>
            //{
            //    new Comment { Id = 1, CustomerId = "1", Text = "Delicious pizza!", Datetime = DateTime.Now.AddDays(-1) },
            //    new Comment { Id = 2, CustomerId = "2", Text = "The hotdog was amazing!", Datetime = DateTime.Now.AddDays(-2) },
            //     Add more comments as needed
            //};

            //modelBuilder.Entity<Comment>().HasData(comments);

            //Seed carts
            //var carts = new List<Cart>
            //{
            //    new Cart { Id = 1, CustomerId = "1", FoodId = 1 },
            //    new Cart { Id = 2, CustomerId = "1", FoodId = 2 },
            //    new Cart { Id = 3, CustomerId = "2", FoodId = 3 },
            //     Add more carts as needed
            //};

            //modelBuilder.Entity<Cart>().HasData(carts);

            // Seed foods
            var foods = new List<Food>
            {
                new Food { Id = 1, FoodName = "Pizza", FoodImgUrl = "pizza.jpg", Price = 30},
                new Food { Id = 2, FoodName = "HotDog", FoodImgUrl = "HotDog.jpg", Price = 1.5},
                new Food { Id = 3, FoodName = "Burger", FoodImgUrl = "burger.jpg", Price = 10},
                new Food { Id = 4, FoodName = "Pasta", FoodImgUrl = "pasta.jpg" , Price = 6},
                // Add more foods as needed
            };

            modelBuilder.Entity<Food>().HasData(foods);

            // Seed ingredients
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Id = 1, IngredientName = "Cheese" },
                new Ingredient { Id = 2, IngredientName = "Tomato Sauce" },
                new Ingredient { Id = 3, IngredientName = "Pepperoni" },
                new Ingredient { Id = 4, IngredientName = "Bun" },
                new Ingredient { Id = 5, IngredientName = "Sausage" },
                new Ingredient { Id = 6, IngredientName = "Lettuce" },
                new Ingredient { Id = 7, IngredientName = "Tomato" },
                new Ingredient { Id = 8, IngredientName = "Mayonnaise" },
                // Add more ingredients as needed
            };

            modelBuilder.Entity<Ingredient>().HasData(ingredients);

            var foodIngredients = new List<FoodIngredient>
            {
                new FoodIngredient { Id = 1, FoodId = 1, IngredientId = 1},
                new FoodIngredient { Id = 2, FoodId = 1, IngredientId = 2},
                new FoodIngredient { Id = 3, FoodId = 1, IngredientId = 3},
                new FoodIngredient { Id = 4, FoodId = 2, IngredientId = 4},
                new FoodIngredient { Id = 5, FoodId = 2, IngredientId = 5},
                new FoodIngredient { Id = 6, FoodId = 3, IngredientId = 4},
                new FoodIngredient { Id = 7, FoodId = 3, IngredientId = 6},
                new FoodIngredient { Id = 8, FoodId = 3, IngredientId = 7},
                new FoodIngredient { Id = 9, FoodId = 3, IngredientId = 8},
                new FoodIngredient { Id = 10, FoodId = 4, IngredientId = 2},
                new FoodIngredient { Id = 11, FoodId = 4, IngredientId = 6},
                new FoodIngredient { Id = 12, FoodId = 4, IngredientId = 7},
            };

            modelBuilder.Entity<FoodIngredient>().HasData(foodIngredients);
        }

    }
}
