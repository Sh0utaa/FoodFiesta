using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFiestaApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string? Text { get; set; }
        public DateTime Datetime { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
