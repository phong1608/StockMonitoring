using Microsoft.EntityFrameworkCore;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Application.Data;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Infrastructure.Repository
{
    public class StockPriceHistoryRepository : IStockPriceHistoryRepository
    {
        private readonly IApplicationDbContext _context;

        public StockPriceHistoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StockPriceHistory history)
        {
            await _context.StockPriceHistories.AddAsync(history);
        }

        public async Task<List<StockPriceHistory>> GetHistoryAsync(string symbol, int take = 100)
        {
            return await _context.StockPriceHistories
                .Where(x => x.Symbol == symbol)
                .OrderByDescending(x => x.Timestamp)
                .Take(take)
                .ToListAsync();
        }
    }

}
