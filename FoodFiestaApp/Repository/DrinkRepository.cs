using AutoMapper;
using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DrinkRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateDrink(DrinkDto model)
        {
            var drink = _mapper.Map<Drink>(model);
            _context.Drinks.Add(drink);
            _context.SaveChanges();
        }

        public void DeleteDrink(int id)
        {
            var model = _context.Drinks.Where(x => x.Id == id).FirstOrDefault();
            if (model is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Remove(model);
                _context.SaveChanges(); 
            }
        }

        public bool DrinkExists(int id)
        {
            return _context.Drinks.Any(x => x.Id == id);
        }

        public Drink GetDrinkById(int Id)
        {
            var drink = _context.Drinks.Where(x => x.Id == Id).FirstOrDefault();
            if (drink is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return drink;
            }
        }

        public Drink GetDrinkByName(string name)
        {
            var drink = _context.Drinks.Where(x => x.Name == name).FirstOrDefault();
            if (drink is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return drink;
            }
        }

        public IEnumerable<Drink> GetDrinks() => _context.Drinks.OrderBy(x => x.Id).ToList();

        public void UpdateDrink(Drink model)
        {
            try
            {
                _context.Drinks.Update(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
