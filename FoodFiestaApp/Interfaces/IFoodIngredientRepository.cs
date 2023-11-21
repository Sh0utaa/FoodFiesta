using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IFoodIngredientRepository
    {
        bool FoodIngredeintExists(int id);
        ICollection<FoodIngredient> GetFoodIngredients();
        FoodIngredient GetFoodIngredient(int id);
        void CreateFoodIngredient(FoodIngredientDto foodIngredientDto);
        void UpdateFoodIngredient(FoodIngredient foodIngredientObject);
        void DeleteFoodIngredient(FoodIngredient foodIngredientObject);
    }
}
