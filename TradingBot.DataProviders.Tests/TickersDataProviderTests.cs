using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class TickersDataProviderTests
    {
        private readonly ITickersDataProvider _provider;

        public TickersDataProviderTests(BybitRestClient httpClient)
        {
            _provider = new TickersDataProvider(new ByBitTradeAdapter(httpClient));
        }

        [Fact]
        public async Task Provide_ReturnNotNullAndNotEmptyResult()
        {
            var tickers = new List<StockTicker>();

            await foreach (var ticker in _provider.Provide())
            {
                tickers.Add(ticker);
            }

            Assert.NotNull(tickers);
            Assert.NotEmpty(tickers);
        }
    }
}
