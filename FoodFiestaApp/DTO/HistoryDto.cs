namespace FoodFiestaApp.DTO
{
    public class HistoryDto
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int FoodId { get; set; }
        public DateTime Datetime { get; set; } = DateTime.Now;
    }
}
