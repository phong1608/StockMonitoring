using Microsoft.AspNetCore.SignalR;

namespace StockMonitoring.Infrastructure.Hubs
{
    public class StockHub:Hub
    {
        public async Task JoinSymbol(string symbol)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, symbol);
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {

            return base.OnDisconnectedAsync(exception);
        }
    }
}
