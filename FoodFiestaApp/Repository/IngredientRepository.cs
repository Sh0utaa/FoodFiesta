using FoodFiestaApp.Data;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _context;
        public IngredientRepository(DataContext context)
        {
            _context = context;
        }
        public Ingredient GetIngredient(string name)
        {
            var singleEngridient = _context.Ingredients.Where(i => i.IngredientName == name).FirstOrDefault();
            return singleEngridient;
        }

        public ICollection<Ingredient> GetIngredients()
        {
            return _context.Ingredients.OrderBy(i => i.Id).ToList();
        }
    }
}
