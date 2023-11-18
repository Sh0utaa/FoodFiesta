using FoodFiestaApp.Data;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DataContext _context;
        public HistoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<History> GetHistories()
        {
            return _context.History.OrderBy(h => h.Id).ToList();
        }
    }
}
