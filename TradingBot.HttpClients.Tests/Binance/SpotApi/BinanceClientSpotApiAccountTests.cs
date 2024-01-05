using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients.SpotApi;

namespace TradingBot.HttpClients.Tests.Binance.SpotApi
{
    public class BinanceRestClientSpotApiAccountTests
    {
        private readonly IBinanceRestClientSpotApiAccount _client;

        public BinanceRestClientSpotApiAccountTests(BinanceRestClient client)
        {
            _client = client.SpotApi.Account;
        }

        [Fact]
        public async Task GetAccountInfoAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.GetAccountInfoAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetAccountStatusAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.GetAccountStatusAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetAssetsForDustTransferAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.GetAssetsForDustTransferAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetBalancesAsync_WithoutParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetBalancesAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetDailySpotAccountSnapshotAsync_WithoutParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetDailySpotAccountSnapshotAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetDepositAddressAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetDepositAddressAsync("USDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetDepositHistoryAsync_WithoutParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetDepositHistoryAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetFundingWalletAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.GetFundingWalletAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetTradingStatusAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.GetTradingStatusAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetUserAssetsAsync_WithoutParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetUserAssetsAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }
    }
}
