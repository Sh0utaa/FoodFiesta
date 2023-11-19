using FoodFiestaApp.DTO;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFiestaApp.Models
{
    public class Customer : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}
