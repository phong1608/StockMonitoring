
using StockMonitoring.Domain.Enum;

namespace StockMonitoring.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserType UserType { get; set; }
        public ICollection<WatchlistItem> Watchlist { get; set; }
    }

}
