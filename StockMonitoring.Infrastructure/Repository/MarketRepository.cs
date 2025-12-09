using Microsoft.EntityFrameworkCore;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Application.Data;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Infrastructure.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly IApplicationDbContext _context;

        public MarketRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Market?> GetByIdAsync(int id)
        {
            return await _context.Markets
                .Include(m => m.Stocks)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Market>> GetAllAsync()
        {
            return await _context.Markets
                .Include(m => m.Stocks)
                .ToListAsync();
        }
    }
}
