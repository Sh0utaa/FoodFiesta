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
        public void CreateFoodIngredient(FoodIngredientDto foodIngredientDto)
        {
            try
            {
                var foodIngredient = new FoodIngredient
                {
                    FoodId = foodIngredientDto.FoodId,
                    IngredientId = foodIngredientDto.IngredientId,
                };
                _context.Add(foodIngredient);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool FoodIngredeintExists(int id)
        {
            return _context.FoodIngredients.Any(f => f.Id == id);
        }

        public void UpdateFoodIngredient(FoodIngredient foodIngredientObject)
        {
            try
            {
                _context.Update(foodIngredientObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
