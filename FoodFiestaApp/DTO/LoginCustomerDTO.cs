using System.ComponentModel.DataAnnotations;

namespace FoodFiestaApp.DTO
{
    public class LoginCustomerDTO
    {
        public string? Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }
    }
}
