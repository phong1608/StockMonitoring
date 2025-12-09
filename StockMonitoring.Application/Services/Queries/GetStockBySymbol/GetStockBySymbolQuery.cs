using StockMonitoring.Application.Common.CQRS;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Services.Queries.GetStockBySymbol
{
    public record GetStockBySymbolQuery(string symbol):IQuery<GetStockBySymbolResult>;

    public record GetStockBySymbolResult(Stock stock);
}
