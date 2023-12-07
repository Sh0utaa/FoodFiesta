using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IDrinkRepository
    {
        bool DrinkExists(int id);
        IEnumerable<Drink> GetDrinks();
        Drink GetDrinkById(int Id);
        Drink GetDrinkByName(string name);
        void CreateDrink(DrinkDto model);
        void UpdateDrink(Drink model);
        void DeleteDrink(int id);

    }
}
