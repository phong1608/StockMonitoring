using Microsoft.AspNetCore.SignalR;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Domain.Models;
using StockMonitoring.Infrastructure.Hubs;

namespace StockMonitoring.Infrastructure.Provider
{
    public class RealtimeWoker(
            IPriceFeedService priceFeed,
            IHubContext<StockHub> hub,
            ActiveSymbolManager symbolManager) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var symbols = symbolManager.GetAllSymbols();
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var symbol in symbols)
                {
                    if(symbol==null) continue;
                    var price = await priceFeed.GetLatestPriceAsync(symbol);
                    if (price is null) continue;

                    var history = new StockPriceHistory
                    {
                        Symbol = symbol,
                        Price = price.Value,
                        Timestamp = DateTime.UtcNow
                    };


                    await hub.Clients.Groups(symbol).SendAsync("StockPriceUpdated", new
                    {
                        Symbol = symbol,
                        Price = price,
                        Timestamp = DateTime.UtcNow
                    });
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
