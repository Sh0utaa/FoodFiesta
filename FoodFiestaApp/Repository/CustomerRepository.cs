using FoodFiestaApp.Data;
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

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }
    }
}
