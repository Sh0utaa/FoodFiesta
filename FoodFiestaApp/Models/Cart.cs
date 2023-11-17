namespace FoodFiestaApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
