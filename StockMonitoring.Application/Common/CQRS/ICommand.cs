using MediatR;

namespace StockMonitoring.Application.Common.CQRS
{
    public interface ICommand : ICommand<Unit>
    {

    }

    public interface ICommand<out IResponse> : IRequest<IResponse>
    {
    }
}
