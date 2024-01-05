using Bybit.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class QuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;

        public QuotesDataProviderTests(BybitRestClient httpClient)
        {
            _adapter = new ByBitTradeAdapter(httpClient);
        }

        [Fact]
        public async Task Provide_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = new List<IQuote>();

            var provider = new QuotesDataProvider(DateTime.UtcNow.AddDays(-3), DateTime.UtcNow,
                Interval.FiveMinutes, _adapter);

            await foreach (var quote in provider.Provide("ETHUSDT"))
            {
                result.Add(quote);
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
