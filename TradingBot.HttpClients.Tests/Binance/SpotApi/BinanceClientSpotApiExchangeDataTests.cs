using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Interfaces.Clients.SpotApi;

namespace TradingBot.HttpClients.Tests.Binance.SpotApi
{
    public class BinanceRestClientSpotApiExchangeDataTests
    {
        private readonly IBinanceRestClientSpotApiExchangeData _client;

        public BinanceRestClientSpotApiExchangeDataTests(BinanceRestClient client)
        {
            _client = client.SpotApi.ExchangeData;
        }

        [Fact]
        public async Task GetAggregatedTradeHistoryAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetAggregatedTradeHistoryAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetAssetDetailsAsync_WithoutParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetAssetDetailsAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetBookPriceAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetBookPriceAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetBookPricesAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetBookPricesAsync(new List<string> { "BTCUSDT", "ETHUSDT" });

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetCurrentAvgPriceAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetCurrentAvgPriceAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetExchangeInfoAsync_WithoutParam_ReturnNotNullResult()
        {
            var response = await _client.GetExchangeInfoAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetKlinesAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetKlinesAsync("ETHUSDT", KlineInterval.OneMinute, 
                DateTime.UtcNow.AddDays(-3), DateTime.UtcNow, 1000);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetOrderBookAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetOrderBookAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Asks);
            Assert.NotNull(response.Data.Bids);

            Assert.NotEmpty(response.Data.Asks);
            Assert.NotEmpty(response.Data.Bids);
        }

        [Fact]
        public async Task GetPriceAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetPriceAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetPricesAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetPricesAsync(new List<string> { "BTCUSDT", "ETHUSDT" });

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRecentTradesAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetRecentTradesAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetServerTimeAsync_WithoutParam_ReturnNotNullResult()
        {
            var response = await _client.GetServerTimeAsync();

            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetSystemStatusAsync_WithoutParam_ReturnNotNullResult()
        {
            var response = await _client.GetSystemStatusAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetTickerAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetTickerAsync("ETHUSDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetTickersAsync(new List<string> { "BTCUSDT", "ETHUSDT" });

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }
    }
}
