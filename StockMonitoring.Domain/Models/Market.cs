namespace StockMonitoring.Domain.Models
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }        // NASDAQ, NYSE, HOSE...
        public string Country { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }

}
