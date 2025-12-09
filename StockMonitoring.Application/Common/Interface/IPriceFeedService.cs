namespace StockMonitoring.Application.Common.Interface
{
    public interface IPriceFeedService
    {
        Task<decimal?> GetLatestPriceAsync(string symbol);
    }
}
