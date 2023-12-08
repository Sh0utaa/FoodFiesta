using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        public CartRepository(DataContext context)
        {
            _context = context;   
        }

        public bool CartExists(int id)
        {
            return _context.Carts.Any(c => c.Id == id);
        }

        public void CreateCart(CartDto cartDto)
        {
            try
            {
                var newCart = new Cart
                {
                    userId = cartDto.UserId,
                    FoodId = cartDto.FoodId,
                    DrinkId = cartDto.DrinkId,
                };

                _context.Add(newCart);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCart(Cart cartObject)
        {
            _context.Remove(cartObject);
            _context.SaveChanges();
        }

        public ICollection<Cart> GetAllCarts()
        {
            return _context.Carts.OrderBy(c => c.Id).ToList();
        }

        public Cart GetCart(int id)
        {
            var singleCart = _context.Carts.Where(c => c.Id == id).FirstOrDefault();
            return singleCart;
        }

        public void UpdateCart(Cart cartObject)
        {
            try
            {
                _context.Update(cartObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
