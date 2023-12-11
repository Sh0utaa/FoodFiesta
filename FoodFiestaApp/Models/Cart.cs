namespace FoodFiestaApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int? userId { get; set; }
        public User? User{ get; set; }
        public int? FoodId { get; set; }
        public Food? Food { get; set; }
    }
}
