using Microsoft.AspNetCore.Identity;

namespace FoodFiestaApp.DTO
{
    public class CustomerDto : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
