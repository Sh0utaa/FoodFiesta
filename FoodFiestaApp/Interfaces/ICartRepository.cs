using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICartRepository
    {
        ICollection<Cart> GetAllCarts();
        void CreateCart(CartDto cartDto);
    }
}
