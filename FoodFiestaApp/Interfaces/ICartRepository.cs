using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICartRepository
    {
        ICollection<Cart> GetAllCarts();
    }
}
