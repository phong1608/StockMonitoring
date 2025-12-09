using Microsoft.EntityFrameworkCore;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Application.Data;
using StockMonitoring.Domain.Models;
using StockMonitoring.Infrastructure.Hubs;

namespace StockMonitoring.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IStockPriceHistoryRepository _stockPriceHistoryRepository;
        private readonly ActiveSymbolManager _symbolManager;

        public StockRepository(IApplicationDbContext context, IStockPriceHistoryRepository stockPriceHistoryRepository,ActiveSymbolManager symbolManager)
        {
            _context = context;
            _stockPriceHistoryRepository = stockPriceHistoryRepository;
            _symbolManager = symbolManager;
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {

            var stock = await _context.Stocks
                .Include(s=>s.Market)
                .FirstOrDefaultAsync(s => s.Symbol == symbol);
            if (!_symbolManager.GetAllSymbols().Contains(symbol))
            {
                _symbolManager.RegisterSymbol(symbol);
            }
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync(int page,int size)
        {
            return await _context.Stocks
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<string> AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            return stock.Symbol;
        }

        public async Task UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);

            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(string symbol)
        {
            return await _context.Stocks.AnyAsync(s => s.Symbol == symbol);
        }

        public async Task UpdateStockPrice(string symbol, decimal newPrice)
        {
            Stock stock = _context.Stocks.First(s => s.Symbol == symbol);
            if(stock==null)
            {
                throw new Exception("Stock is not found");

            }
            stock.CurrentPrice = newPrice;
            await _context.SaveChangesAsync();
            await _stockPriceHistoryRepository.AddAsync(new StockPriceHistory
            {
                Symbol = symbol,
                Price = newPrice,
                Timestamp = DateTime.UtcNow
            });
        }

        public Task<List<string>> GetAllSymbol()
        {
            var symbols = _context.Stocks.Select(s => s.Symbol).ToListAsync();
            return symbols;
        }
    }
}

