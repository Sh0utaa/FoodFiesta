using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface IHistoryRepository
    {
        ICollection<History> GetHistories();
    }
}
