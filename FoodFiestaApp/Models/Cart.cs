namespace FoodFiestaApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // Navigation property
        public int FoodId { get; set; }
        public Food Food { get; set; } // Navigation property
    }
}
