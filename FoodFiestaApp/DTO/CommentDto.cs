namespace FoodFiestaApp.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Text { get; set; }
        public double? Rating { get; set; }
        public DateTime Datetime { get; set; }
    }
}
