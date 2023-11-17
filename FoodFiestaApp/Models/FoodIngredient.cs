namespace FoodFiestaApp.Models
{
    public class FoodIngredient
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food? Food { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
