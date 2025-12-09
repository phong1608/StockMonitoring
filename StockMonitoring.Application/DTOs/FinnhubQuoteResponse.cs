namespace StockMonitoring.Application.DTOs
{
    public class FinnhubQuoteResponse
    {
        // Current price
        public decimal c { get; set; }

        // Change
        public decimal d { get; set; }

        // Percent change
        public decimal dp { get; set; }

        // High price of the day
        public decimal h { get; set; }

        // Low price of the day
        public decimal l { get; set; }

        // Open price of the day
        public decimal o { get; set; }

        // Previous close price
        public decimal pc { get; set; }

        // Timestamp (Unix)
        public long t { get; set; }
    }


}
