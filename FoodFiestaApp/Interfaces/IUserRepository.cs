using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUserByName(string name);
        void CreateUser(User user);
        bool UserExists(int id);
        void UpdateUser(User customerObject);
        void DeleteUser(User customerObject);
    }
}
