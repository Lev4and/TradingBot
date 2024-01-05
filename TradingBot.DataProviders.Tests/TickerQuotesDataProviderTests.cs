using Bybit.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class TickerQuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;
        private readonly ITickersDataProvider _tickersDataProvider;

        public TickerQuotesDataProviderTests(BybitRestClient httpClient)
        {
            _adapter = new ByBitTradeAdapter(httpClient);
            _tickersDataProvider = new TickersDataProvider(_adapter);
        }

        [Fact]
        public async Task Provide_ReturnNotNullAndNotEmptyResult()
        {
            var result = new List<KeyValuePair<StockTicker, IQuote>>();

            var provider = new TickerQuotesDataProvider(new QuotesDataProvider(DateTime.UtcNow.AddDays(-7),
                DateTime.UtcNow, Interval.OneDay, _adapter), _tickersDataProvider);

            await foreach (var item in provider.Provide())
            {
                result.Add(new KeyValuePair<StockTicker, IQuote>(item.Key, item.Value));
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
