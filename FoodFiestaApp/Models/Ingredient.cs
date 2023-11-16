using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFiestaApp.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string? IngredientName { get; set; }

        // Navigation property for the one-to-many relationship
        public Food Food { get; set; }
    }
}
