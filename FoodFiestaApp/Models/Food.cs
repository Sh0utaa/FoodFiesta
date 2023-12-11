namespace FoodFiestaApp.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public double? Price { get; set; }

        public ICollection<Cart>? Cart { get; set; }
    }
}
