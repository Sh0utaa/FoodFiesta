using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class FoodIngredientRepository : IFoodIngredientRepository
    {
        private readonly DataContext _context;
        public FoodIngredientRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<FoodIngredient> GetFoodIngredients()
        {
            return _context.FoodIngredients.OrderBy(x => x.Id).ToList();
        }
    }
}
