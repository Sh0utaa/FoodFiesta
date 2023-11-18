using FoodFiestaApp.Data;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly DataContext _context;
        public FoodRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Food> GetFood()
        {
            return _context.Foods.OrderBy(x => x.Id).ToList();
        }
        public Food GetFoodById(int id)
        {
            var foodItem = _context.Foods.Where(x => x.Id == id).FirstOrDefault();
            return foodItem;
        }
        public Food GetFood(string name)
        {
            var foodItem =_context.Foods.Where(x => x.FoodName == name).FirstOrDefault();
            return foodItem;
        }

        public bool CreateFood(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
