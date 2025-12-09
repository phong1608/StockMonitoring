using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IAlertRuleRepository
    {
        Task<List<AlertRule>> GetActiveRulesBySymbolAsync(string symbol);
        Task AddAsync(AlertRule rule);
        Task DeactivateAsync(Guid id);
    }
}
