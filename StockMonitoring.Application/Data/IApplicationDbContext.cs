using Microsoft.EntityFrameworkCore;
using StockMonitoring.Domain.Models;
using System.Collections.Generic;

namespace StockMonitoring.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Stock> Stocks { get; }
        DbSet<Market> Markets { get; }
        DbSet<StockPriceHistory> StockPriceHistories { get; }
        DbSet<User> Users { get; }
        DbSet<WatchlistItem> WatchlistItems { get; }
        DbSet<AlertRule> AlertRules { get; }
        DbSet<Notification> Notifications { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
