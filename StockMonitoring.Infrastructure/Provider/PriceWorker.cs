using Microsoft.AspNetCore.SignalR;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Domain.Models;
using StockMonitoring.Infrastructure.Hubs;

namespace StockMonitoring.Infrastructure.Provider
{
    public class PriceWorker(
        IPriceFeedService priceFeed,
        IStockRepository stockRepository) : BackgroundService
    {
      
        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var symbols = await stockRepository.GetAllSymbol();
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var symbol in symbols)
                {
                    var price = await priceFeed.GetLatestPriceAsync(symbol);
                    if (price is null) continue;

                    var history = new StockPriceHistory
                    {
                        Symbol = symbol,
                        Price = price.Value,
                        Timestamp = DateTime.UtcNow
                    };

                    await stockRepository.UpdateStockPrice(symbol, price.Value);

                    
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
