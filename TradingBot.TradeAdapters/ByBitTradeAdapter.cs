using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.ByBit;

namespace TradingBot.TradeAdapters
{
    public class ByBitTradeAdapter : ITradeAdapter
    {
        private readonly BybitRestClient _client;

        public ByBitTradeAdapter(BybitRestClient client)
        {
            _client = client;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync(code);
            var ticker = response?.Data?.List?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response?.Data?.List?.Select(symbol => symbol.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var response = await _client.V5Api.ExchangeData.GetKlinesAsync(Category.Spot, code, 
                interval.MapInterval(), from, to);
            var klines = response?.Data;

            return response?.Data?.List?.Select(kline => kline.ToQuote()) ?? Enumerable.Empty<Quote>();
        }
    }
}
