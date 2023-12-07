namespace FoodFiestaApp.Models
{
    public class Drink
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? ImgPath { get; set; }

        public ICollection<Cart>? Cart { get; set; }

    }
}
