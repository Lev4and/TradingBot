﻿using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;

namespace TradingBot.TradeAdapters
{
    public class ByBitTradeAdapter : ITradeAdapter
    {
        private readonly BybitClient _client;
        private readonly ByBitConverter _converter;

        public ByBitTradeAdapter(BybitClient client, ByBitConverter converter)
        {
            _client = client;
            _converter = converter;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync(code);

            var ticker = response?.Data?.List?.SingleOrDefault();

            return ticker != null ?  _converter.Ticker.Convert(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response?.Data?.List?.Select(_converter.Ticker.Convert) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var response = await _client.V5Api.ExchangeData
                .GetKlinesAsync(Category.Spot, code, _converter.Interval.Convert(interval), from, to);

            var klines = response?.Data;

            return response?.Data?.List?.Select(_converter.Quote.Convert) ?? Enumerable.Empty<Quote>();
        }
    }
}
