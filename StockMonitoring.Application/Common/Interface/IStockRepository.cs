using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IStockRepository
    {
        Task<Stock?> GetBySymbolAsync(string symbol);
        Task<List<Stock>> GetAllAsync(int page,int size);
        Task<string> AddAsync(Stock stock);
        Task UpdateAsync(Stock stock);
        Task UpdateStockPrice(string symbol, decimal newPrice);
        Task<bool> ExistsAsync(string symbol);
        Task<List<string>> GetAllSymbol();
    }
}
