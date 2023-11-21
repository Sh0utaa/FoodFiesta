using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(p => p.Id).ToList();
        }
        public Customer GetCustomer(string id)
        {
            var singleCustomer = _context.Customers.Where(p => p.Id == id).FirstOrDefault();
            return singleCustomer;
        }

        public bool CustomerExists(string id)
        {
            var customerExists = _context.Customers.Any(p => p.Id == id);
            return customerExists;
        }

        public void CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                var newCustomer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    UserName = customerDto.UserName,
                    NormalizedUserName = customerDto.NormalizedUserName,
                    Email = customerDto.Email,
                    NormalizedEmail = customerDto.NormalizedEmail,
                    EmailConfirmed = customerDto.EmailConfirmed,
                    PasswordHash = customerDto.PasswordHash,
                    PhoneNumber = customerDto.PhoneNumber,
                    PhoneNumberConfirmed = customerDto.PhoneNumberConfirmed,
                    TwoFactorEnabled = customerDto.TwoFactorEnabled,
                    LockoutEnd = customerDto.LockoutEnd,
                    LockoutEnabled = customerDto.LockoutEnabled,
                    AccessFailedCount = customerDto.AccessFailedCount
                };
                _context.Add(newCustomer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCustomer(Customer customerObject)
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

        public void DeleteCustomer(Customer customerObject)
        {
            // Remove references from Carts & Comments
            var allCarts = _context.Carts.Where(ca => ca.CustomerId == customerObject.Id);
            var allComments = _context.Comments.Where(co => co.CustomerId == customerObject.Id);
            _context.Carts.RemoveRange(allCarts);
            _context.Comments.RemoveRange(allComments);

            _context.Remove(customerObject);
            _context.SaveChanges();
        }
    }
}
