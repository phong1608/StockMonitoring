using StockMonitoring.Application.Common.CQRS;
using StockMonitoring.Application.Common.Interface;
using System.Diagnostics;

namespace StockMonitoring.Application.Services.Queries.GetStockBySymbol
{
    public class GetStockBySymbolHandler(IStockRepository stockRepository) : IQueryHandler<GetStockBySymbolQuery, GetStockBySymbolResult>
    {
        public async Task<GetStockBySymbolResult> Handle(GetStockBySymbolQuery request, CancellationToken cancellationToken)
        {
            var stocks = await stockRepository.GetBySymbolAsync(request.symbol);
            return new GetStockBySymbolResult(stocks);
        }
    }
}
