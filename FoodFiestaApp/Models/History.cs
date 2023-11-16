namespace FoodFiestaApp.Models
{
    public class History
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public DateTime Datetime { get; set; } = DateTime.Now;
    }
}
