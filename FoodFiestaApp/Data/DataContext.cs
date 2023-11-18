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
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<History> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);

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

            // Configure many-to-many relationship between Food and Ingredient through FoodIngredientTable
            modelBuilder.Entity<FoodIngredient>()
                .HasKey(f => new { f.FoodId, f.IngredientId });

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(f => f.Food)
                .WithMany(fu => fu.FoodIngredientTable)
                .HasForeignKey(f => f.FoodId);

            modelBuilder.Entity<FoodIngredient>()
                .HasOne(f => f.Ingredient)
                .WithMany(fu => fu.FoodIngredientTable)
                .HasForeignKey(f => f.IngredientId);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed customers
            var customers = new List<Customer>
            {
                new Customer { Id = "1", FirstName = "John", LastName = "Doe", UserName = "JohnDoe_27", Email = "john.doe@example.com" },
                new Customer { Id = "2", FirstName = "Jane", LastName = "Smith", UserName = "JaneSmith_07", Email = "jane.smith@example.com" },
                // Add more customers as needed
            };

            modelBuilder.Entity<Customer>().HasData(customers);

            // Seed comments
            var comments = new List<Comment>
            {
                new Comment { Id = 1, CustomerId = "1", Text = "Delicious pizza!", Datetime = DateTime.Now.AddDays(-1) },
                new Comment { Id = 2, CustomerId = "2", Text = "The hotdog was amazing!", Datetime = DateTime.Now.AddDays(-2) },
                // Add more comments as needed
            };

            modelBuilder.Entity<Comment>().HasData(comments);

            // Seed carts
            var carts = new List<Cart>
            {
                new Cart { Id = 1, CustomerId = "1", FoodId = 1 },
                new Cart { Id = 2, CustomerId = "1", FoodId = 2 },
                new Cart { Id = 3, CustomerId = "2", FoodId = 3 },
                // Add more carts as needed
            };

            modelBuilder.Entity<Cart>().HasData(carts);

            // Seed history
            var history = new List<History>
            {
                new History { Id = 1, CustomerId = "1", FoodId = 1, Datetime = DateTime.Now.AddDays(-5) },
                new History { Id = 2, CustomerId = "2", FoodId = 2, Datetime = DateTime.Now.AddDays(-10) },
                // Add more history entries as needed
            };

            modelBuilder.Entity<History>().HasData(history);
            // Seed foods
            var foods = new List<Food>
            {
                new Food { Id = 1, FoodName = "Pizza", FoodImgUrl = "pizza.jpg" },
                new Food { Id = 2, FoodName = "HotDog", FoodImgUrl = "HotDog.jpg" },
                new Food { Id = 3, FoodName = "Burger", FoodImgUrl = "burger.jpg" },
                new Food { Id = 4, FoodName = "Pasta", FoodImgUrl = "pasta.jpg" },
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
