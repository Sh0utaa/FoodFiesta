namespace FoodFiestaApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool Admin { get; set; } = false;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Cart>? Cart { get; set; }
    }
}
