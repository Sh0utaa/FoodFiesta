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
                    CustomerId = cartDto.CustomerId,
                    FoodId = cartDto.FoodId,
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
