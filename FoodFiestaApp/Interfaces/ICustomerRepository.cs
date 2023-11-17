using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
    }
}
