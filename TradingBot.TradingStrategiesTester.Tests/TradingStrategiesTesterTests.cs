using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.DataProviders;
using TradingBot.TechnicalAnalyze.Strategies;
using TradingBot.TradeAdapters;

namespace TradingBot.TradingStrategiesTester.Tests
{
    public class TradingStrategiesTesterTests
    {
        private readonly ITradeAdapter _adapter;
        private readonly ITickersDataProvider _tickersDataProvider;

        public TradingStrategiesTesterTests(BybitRestClient httpClient) 
        {
            _adapter = new ByBitTradeAdapter(httpClient);
            _tickersDataProvider = new TickersDataProvider(_adapter);
        }

        [Fact]
        public async Task TestAsync()
        {
            var strategy = new Lev4andTradingStrategy();

            var poorTrader = new SimulationTrader(new Wallets() { { "USDT", new Wallet("USDT", 50) } }, strategy);
            var middleTrader = new SimulationTrader(new Wallets() { { "USDT", new Wallet("USDT", 500) } }, strategy);
            var richTrader = new SimulationTrader(new Wallets() { { "USDT", new Wallet("USDT", 5000) } }, strategy);

            var traders = new List<ISimulationTrader>() { poorTrader, middleTrader, richTrader };

            var quotesDataProvider = new QuotesDataProvider(DateTime.UtcNow.AddYears(-2), DateTime.UtcNow, 
                Interval.OneDay, _adapter);

            var tickersQuotesDataProvider = new TickerQuotesDataProvider(quotesDataProvider, _tickersDataProvider);

            var tester = new TradingStrategiesTester(traders, tickersQuotesDataProvider);

            tester.Start();

            while (tester.IsRunning)
            {
                await Task.Delay(100);
            }

            Assert.NotNull(tester.TickersQuotes);
            Assert.NotEmpty(tester.TickersQuotes);
        }
    }
}
