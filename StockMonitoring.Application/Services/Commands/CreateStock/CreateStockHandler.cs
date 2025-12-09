using StockMonitoring.Application.Common.CQRS;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Services.Commands.CreateStock
{
    public class CreateStockHandler(IStockRepository stockRepository) : ICommandHandler<CreateStockCommand, CreateStockResult>
    {

        public async Task<CreateStockResult> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            string symbol = await stockRepository.AddAsync(request.stock);
            return new CreateStockResult(symbol);
        }
    }
}
