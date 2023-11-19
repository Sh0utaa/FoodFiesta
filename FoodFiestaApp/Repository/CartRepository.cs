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

        public ICollection<Cart> GetAllCarts()
        {
            return _context.Carts.OrderBy(c => c.Id).ToList();
        }
    }
}
