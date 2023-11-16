namespace FoodFiestaApp.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public string? FoodImgUrl { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<History> History { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
