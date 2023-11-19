namespace FoodFiestaApp.DTO
{
    public class CommentDto
    {
        public string CustomerId { get; set; }
        public string? Text { get; set; }
        public double? Rating { get; set; }
        public DateTime Datetime { get; set; }
    }
}
