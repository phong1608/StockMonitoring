namespace StockMonitoring.Domain.Models
{
    public class WatchlistItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Symbol { get; set; }
        public DateTime AddedDate { get; set; }

        public User User { get; set; }
        public Stock Stock { get; set; }
    }

}
