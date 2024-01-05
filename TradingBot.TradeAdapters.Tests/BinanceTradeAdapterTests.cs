using Binance.Net.Clients;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters.Tests
{
    public class BinanceTradeAdapterTests
    {
        private readonly ITradeAdapter _adapter;

        public BinanceTradeAdapterTests(BinanceRestClient client)
        {
            _adapter = new BinanceTradeAdapter(client);
        }

        [Fact]
        public async Task GetTicker_WithParam_ReturnNotNullResult()
        {
            var result = await _adapter.GetTicker("ETHUSDT");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTicker_WithInvalidParam_ThrowException()
        {
            var action = async () => await _adapter.GetTicker("AAAUSDT");

            await Assert.ThrowsAsync<NotSupportedException>(action);
        }

        [Fact]
        public async Task GetTickers_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _adapter.GetTickers();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetHistoricalQuotes_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _adapter.GetHistoricalQuotes("ETHUSDT", Interval.OneDay, 
                DateTime.UtcNow.AddMonths(-2), DateTime.UtcNow);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
