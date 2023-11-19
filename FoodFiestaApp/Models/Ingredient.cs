using FoodFiestaApp.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFiestaApp.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? IngredientName { get; set; }
        public ICollection<FoodIngredient> FoodIngredientTable { get; set; }
    }
}
