using System.Collections.Concurrent;

namespace StockMonitoring.Infrastructure.Hubs
{
    public class ActiveSymbolManager
    {
        private readonly ConcurrentDictionary<string, int> _symbolSubscribers = new();

        public void RegisterSymbol(string symbol)
        {
            _symbolSubscribers.AddOrUpdate(symbol, 1, (_, count) => count + 1);
        }

        public void UnregisterSymbol(string symbol)
        {
            _symbolSubscribers.AddOrUpdate(symbol, 0, (_, count) => Math.Max(0, count - 1));
        }
        public List<String> GetAllSymbols()
        {
            return _symbolSubscribers.Keys.ToList();
        }

    }
}
