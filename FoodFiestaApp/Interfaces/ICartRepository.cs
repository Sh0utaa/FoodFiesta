using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICartRepository
    {
        ICollection<Cart> GetAllCarts();
        bool CartExists(int id);
        void CreateCart(CartDto cartDto);
        void UpdateCart(Cart cartObject);
    }
}
