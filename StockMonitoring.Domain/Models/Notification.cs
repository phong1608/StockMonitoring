namespace StockMonitoring.Domain.Models
{
    public class Notification
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Symbol { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }

        public User User { get; set; }
    }

}
