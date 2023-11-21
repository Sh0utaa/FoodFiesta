using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IIngredientRepository
    {
        ICollection<Ingredient> GetIngredients();
        bool IngredientExists(int id);
        Ingredient GetIngredientById(int id);
        Ingredient GetIngredient(string name);
        void CreateIngredient(IngredientDto ingredient);
        void UpdateIngredient(Ingredient ingredientObject);
        void DeleteIngredient(Ingredient ingredientObject);
    }
}
