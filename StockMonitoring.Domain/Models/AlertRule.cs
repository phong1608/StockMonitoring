namespace StockMonitoring.Domain.Models
{
    public class AlertRule
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }

        public AlertType Type { get; set; }
        public decimal TargetValue { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Stock Stock { get; set; }
    }

    public enum AlertType
    {
        PriceAbove,
        PriceBelow,
        PercentChange
    }

}
