using Microsoft.EntityFrameworkCore;
using StockMonitoring.Application.Data;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<StockPriceHistory> StockPriceHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchlistItem> WatchlistItems { get; set; }
        public DbSet<AlertRule> AlertRules { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =============================
            // Stock
            // =============================
            modelBuilder.Entity<Stock>()
                .HasKey(s => s.Symbol);

         


            // =============================
            // Market
            // =============================
            modelBuilder.Entity<Market>()
                .HasKey(m => m.Id);


            // =============================
            // StockPriceHistory
            // =============================
            modelBuilder.Entity<StockPriceHistory>()
                .HasOne(h => h.Stock)
                .WithMany()
                .HasForeignKey(h => h.Symbol)
                .OnDelete(DeleteBehavior.Cascade);


            // =============================
            // User
            // =============================
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);


            // =============================
            // WatchlistItem
            // =============================
            modelBuilder.Entity<WatchlistItem>()
                .HasOne(w => w.User)
                .WithMany(u => u.Watchlist)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WatchlistItem>()
                .HasOne(w => w.Stock)
                .WithMany()
                .HasForeignKey(w => w.Symbol)
                .OnDelete(DeleteBehavior.Cascade);


            // =============================
            // AlertRule
            // =============================
            modelBuilder.Entity<AlertRule>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AlertRule>()
                .HasOne(a => a.Stock)
                .WithMany()
                .HasForeignKey(a => a.Symbol)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
