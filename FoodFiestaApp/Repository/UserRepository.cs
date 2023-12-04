using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodFiestaApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }
        public User GetUser(int id)
        {
            var singleCustomer = _context.Users.Where(p => p.Id == id).FirstOrDefault();
            return singleCustomer;
        }
        public User GetUserByName(string name)
        {
            var singleUser = _context.Users.Where(p => p.Username == name).FirstOrDefault();
            return singleUser;
        }

        public bool UserExists(int id)
        {
            var customerExists = _context.Users.Any(p => p.Id == id);
            return customerExists;
        }

        public void UpdateUser(User customerObject)
        {
            try
            {
                _context.Update(customerObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUser(User customerObject)
        {
            var allCarts = _context.Carts.Where(ca => ca.userId == customerObject.Id);
            var allComments = _context.Comments.Where(co => co.userId == customerObject.Id);
            _context.Carts.RemoveRange(allCarts);
            _context.Comments.RemoveRange(allComments);

            _context.Remove(customerObject);
            _context.SaveChanges();
        }

        public void CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
