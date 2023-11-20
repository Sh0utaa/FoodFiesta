using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
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

        public void CreateFood(FoodDto foodDto)
        {
            try
            {
                var food = new Food
                {
                    FoodName = foodDto.FoodName,
                    Price = foodDto.Price,
                    FoodImgUrl = foodDto.FoodImgUrl
                };
                _context.Foods.Add(food);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Error creating food", ex);
            }
        }

        public void UpdateFood(Food foodObject)
        {
            try
            {
                _context.Update(foodObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool FoodExists(int id)
        {
            return _context.Foods.Any(f => f.Id == id);
        }

        public void DeleteFood(Food foodObject)
        {
            _context.Remove(foodObject);
            _context.SaveChanges();
        }
    }
}
