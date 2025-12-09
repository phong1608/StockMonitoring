using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IStockPriceHistoryRepository
    {
        Task AddAsync(StockPriceHistory history);
        Task<List<StockPriceHistory>> GetHistoryAsync(string symbol, int take = 100);
    }
}
