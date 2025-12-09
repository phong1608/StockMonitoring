using StockMonitoring.Application.Common.CQRS;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Services.Commands.CreateStock
{
    public record CreateStockCommand(Stock stock) :ICommand<CreateStockResult>;
    public record CreateStockResult(string Symbol);


}
