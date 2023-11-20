using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(string id);
        bool CustomerExists(string id);
        void CreateCustomer(CustomerDto customerDto);
        void UpdateCustomer(Customer customerObject);
    }
}
