using StockMonitoring.Application.Common.CQRS;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Services.Queries.GetStock
{
    public record GetStockQuery(int page=1,int size=10) : IQuery<GetStockQueryResult>;
    public record GetStockQueryResult(List<Stock> stock);
    
}
