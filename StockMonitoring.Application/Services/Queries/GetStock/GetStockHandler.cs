using StockMonitoring.Application.Common.CQRS;
using StockMonitoring.Application.Common.Interface;

namespace StockMonitoring.Application.Services.Queries.GetStock
{
    public class GetStockHandler(IStockRepository stockRepository) : IQueryHandler<GetStockQuery, GetStockQueryResult>
    {
        public async Task<GetStockQueryResult> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stocks = await stockRepository.GetAllAsync(request.page, request.size);
            return new GetStockQueryResult(stocks);
        }
    }
}
