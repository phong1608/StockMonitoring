using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Application.DTOs;
using System.Text.Json;

namespace StockMonitoring.Infrastructure.Provider
{
    public class FinnhubPriceFeedService(HttpClient client, IConfiguration config) : IPriceFeedService
    {
        private readonly HttpClient _client = client;
        private readonly string _apiKey = config["Finnhub:ApiKey"] ?? throw new ArgumentNullException("Finnhub API key is not configured.");
        
        public async Task<decimal?> GetLatestPriceAsync(string symbol)
        {
            var response = await _client.GetFromJsonAsync<FinnhubQuoteResponse>(
                           $"quote?symbol={symbol}&token={_apiKey}"
                       );
            var currentPrice = response.c;
            return currentPrice;
        }

        
    }
}
