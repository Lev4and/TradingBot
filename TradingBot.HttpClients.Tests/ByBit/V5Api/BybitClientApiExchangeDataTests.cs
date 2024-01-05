using Bybit.Net.Clients;
using Bybit.Net.Enums;
//using Okex.Net;
using OKX.Api;
namespace TradingBot.HttpClients.Tests.ByBit.V5Api
{
    public class ExchangeDataApiTests
    {
        public readonly BybitRestClient _client;

        public ExchangeDataApiTests(BybitRestClient client)
        {
            _client = client;
        }

        [Fact]
        public async Task GetKlinesAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _client.V5Api.ExchangeData.GetKlinesAsync(Category.Spot, "ETHUSDT",
                KlineInterval.OneMinute, DateTime.UtcNow.AddDays(-3), DateTime.UtcNow, 1000);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.List);
            Assert.NotEmpty(response.Data.List);
        }

        [Fact]
        public async Task GetOrderbookAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _client.V5Api.ExchangeData.GetOrderbookAsync(Category.Spot, "ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Asks);
            Assert.NotNull(response.Data.Bids);

            Assert.NotEmpty(response.Data.Asks);
            Assert.NotEmpty(response.Data.Bids);
        }

        [Fact]
        public async Task GetSpotSymbolsAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.List);
            Assert.NotEmpty(response.Data.List);
        }

        [Fact]
        public async Task GetSpotTickersAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotTickersAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.List);
            Assert.NotEmpty(response.Data.List);
        }
    }
}
