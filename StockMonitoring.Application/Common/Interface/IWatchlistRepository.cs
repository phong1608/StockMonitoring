using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IWatchlistRepository
    {
        Task<List<WatchlistItem>> GetByUserAsync(int userId);
        Task AddAsync(WatchlistItem item);
        Task RemoveAsync(int id);
    }
}
