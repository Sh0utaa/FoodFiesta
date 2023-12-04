using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFiestaApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? userId { get; set; }
        public string? Text { get; set; }
        public double? Rating { get; set; }
        public DateTime Datetime { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }
    }
}
