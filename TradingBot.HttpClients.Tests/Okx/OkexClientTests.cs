using OKX.Api;
using OKX.Api.Clients.RestApi;
using OKX.Api.Enums;

namespace TradingBot.HttpClients.Tests.Okx
{
    public class OkexClientTests
    {
        private readonly OKXRestApiClient _client;

        public OkexClientTests(OKXRestApiClient client)
        {
            _client = client;
        }

        [Fact]
        public async Task GetTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.OrderBookTrading.MarketData.GetTickersAsync(OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetTickerAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.OrderBookTrading.MarketData.GetTickerAsync("ETH-USDT-SWAP");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetIndexTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.PublicData.GetIndexTickersAsync(quoteCurrency: "USDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetOrderBookAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.OrderBookTrading.MarketData.GetOrderBookAsync("ETH-USDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Asks);
            Assert.NotNull(response.Data.Bids);

            Assert.NotEmpty(response.Data.Asks);
            Assert.NotEmpty(response.Data.Bids);
        }

        [Fact]
        public async Task GetCandlesticksHistoryAsync_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.OrderBookTrading.MarketData.GetCandlesticksHistoryAsync("BTC-USDT", OkxPeriod.OneMinute);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetTradesAsync_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.OrderBookTrading.MarketData.GetTradesAsync("ETH-USDT", 500);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetBlockTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.BlockTrading.GetBlockTickersAsync(OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetInstrumentsAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.PublicData.GetInstrumentsAsync(OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetSystemTimeAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.PublicData.GetServerTimeAsync();

            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetRubikTakerVolumeAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.TradingStatistics.GetTakerVolumeAsync("ETH", OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRubikLongShortRatioAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.TradingStatistics.GetLongShortRatioAsync("ETH");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRubikPutCallRatioAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.TradingStatistics.GetPutCallRatioAsync("BTC", OkxPeriod.OneDay);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRubikTakerFlowAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.TradingStatistics.GetTakerFlowAsync("BTC", OkxPeriod.OneDay);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetAccountBalance_Async_WithoutParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.TradingAccount.GetAccountBalanceAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Details);
            Assert.NotEmpty(response.Data.Details);
        }

        [Fact]
        public async Task GetCurrenciesAsync_Async_WithoutParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.FundingAccount.GetCurrenciesAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }
    }
}
