using Microsoft.EntityFrameworkCore;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Domain.Models;
using StockMonitoring.Infrastructure.Data;

namespace StockMonitoring.Infrastructure.Repository
{
    public class AlertRepository : IAlertRuleRepository
    {
        private readonly ApplicationDbContext _context;

        public AlertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AlertRule?> GetByIdAsync(Guid id)
        {
            return await _context.AlertRules.FindAsync(id);
        }

        public async Task<List<AlertRule>> GetByUserAsync(Guid userId)
        {
            return await _context.AlertRules
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(AlertRule alert)
        {
            _context.AlertRules.Add(alert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AlertRule alert)
        {
            _context.AlertRules.Update(alert);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateAsync(Guid id)
        {
            var alert = await _context.AlertRules.FindAsync(id);
            if (alert != null)
            {
                _context.AlertRules.Remove(alert);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<AlertRule>> GetActiveRulesBySymbolAsync(string symbol)
        {
            throw new NotImplementedException();
        }

        

       
    }
}
