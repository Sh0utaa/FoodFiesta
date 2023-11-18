using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IFoodRepository
    {
        ICollection<Food> GetFood();
        Food GetFoodById(int id);
        Food GetFood(string name);
        bool CreateFood(int IngredientId,Food food);
    }
}
