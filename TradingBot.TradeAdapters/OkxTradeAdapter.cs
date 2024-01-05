using OKX.Api;
using OKX.Api.Clients.RestApi;
using OKX.Api.Enums;
using OKX.Api.Helpers;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.Okx;
using System;
using ApiSharp.Extensions;
namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter
    {
        private readonly OKXRestApiPublicDataClient _client;
        private readonly OKXRestApiMarketDataClient _rclient;
        public OkxTradeAdapter(OKXRestApiPublicDataClient client, OKXRestApiMarketDataClient rclient)
        {
            _client = client;
            _rclient=rclient;    
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.GetInstrumentsAsync(OkxInstrumentType.Spot, instrumentId: code);
            var ticker = response?.Data?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.GetInstrumentsAsync(OkxInstrumentType.Spot);

            return response?.Data?.Select(instrument => instrument.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            
            var response = await _rclient.GetCandlesticksHistoryAsync(code, interval.MapInterval(), DateTime.UnixEpoch.AddMilliseconds(to.ConvertToMilliseconds()).Second
                , DateTime.UnixEpoch.AddMilliseconds(from.ConvertToMilliseconds()).Second);
            var klines = response?.Data;

            return response?.Data?.Select(kline => kline.ToQuote()) ?? Enumerable.Empty<Quote>();
        }
    }
}
