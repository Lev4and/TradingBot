using Binance.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.Binance;

namespace TradingBot.TradeAdapters
{
    public class BinanceTradeAdapter : ITradeAdapter
    {
        private readonly BinanceRestClient _client;

        public BinanceTradeAdapter(BinanceRestClient client)
        {
            _client = client;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync(code);
            var ticker = response?.Data?.Symbols?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync();

            return response?.Data?.Symbols?.Select(symbol => symbol.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var response = await _client.SpotApi.ExchangeData.GetKlinesAsync(code, interval.MapInterval(), from, to);
            var klines = response?.Data;

            return response?.Data?.Select(kline => kline.ToQuote()) ?? Enumerable.Empty<Quote>();
        }
    }
}
