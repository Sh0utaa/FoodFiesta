using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IFoodIngredientRepository
    {
        ICollection<FoodIngredient> GetFoodIngredients();
        void CreateFoodIngredient(FoodIngredientDto foodIngredientDto);
    }
}
