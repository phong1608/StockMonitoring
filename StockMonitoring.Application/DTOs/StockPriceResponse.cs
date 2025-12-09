namespace StockMonitoring.Application.DTOs
{
    public class StockPriceResponse
    {
        public string Symbol { get; set; }
        public decimal NewPrice { get; set; }
        public decimal PercentChange { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
