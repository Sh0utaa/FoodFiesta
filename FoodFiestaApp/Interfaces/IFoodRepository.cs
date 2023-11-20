using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IFoodRepository
    {
        bool FoodExists(int id);
        ICollection<Food> GetFood();
        Food GetFoodById(int id);
        Food GetFood(string name);
        void CreateFood(FoodDto foodDto);
        void UpdateFood(Food foodObject);
    }
}
