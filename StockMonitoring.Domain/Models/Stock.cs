namespace StockMonitoring.Domain.Models
{
    public class Stock
    {
        public string Symbol { get; set; }      // Mã cổ phiếu: AAPL, MSFT...
        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousClosePrice { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal DayHigh { get; set; }
        public decimal DayLow { get; set; }
        public DateTime LastUpdated { get; set; }

        // Optional: Market
        public int MarketId { get; set; }
        public Market Market { get; set; }
    }

}
