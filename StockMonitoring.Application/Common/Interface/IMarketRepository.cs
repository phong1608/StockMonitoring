using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IMarketRepository
    {
        Task<Market?> GetByIdAsync(int id);
        Task<List<Market>> GetAllAsync();
    }
}
