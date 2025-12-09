using StockMonitoring.Application.Data;
using StockMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Infrastructure.Provider;
using StockMonitoring.Infrastructure.Repository;

namespace StockMonitoring.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            // Add services to the container.
            //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            //services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
            services.AddScoped<IStockRepository,StockRepository>();
            services.AddScoped<IStockPriceHistoryRepository,StockPriceHistoryRepository>();
            services.AddScoped<IPriceFeedService, FinnhubPriceFeedService>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddHttpClient<IPriceFeedService, FinnhubPriceFeedService>(client =>
            {
                client.BaseAddress = new Uri("https://finnhub.io/api/v1/");
            });
            services.AddSignalR();
            return services;
        }

    }
}
