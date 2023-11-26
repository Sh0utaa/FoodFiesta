using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(string id);
        bool CustomerExists(string id);
        void CreateCustomer(RegisterCustomerDTO customerDto);
        void UpdateCustomer(Customer customerObject);
        void DeleteCustomer(Customer customerObject);
    }
}
