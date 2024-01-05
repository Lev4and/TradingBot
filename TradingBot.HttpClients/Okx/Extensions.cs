using OKX.Api.Enums;
using OKX.Api.Models.MarketData;
using OKX.Api.Models.PublicData;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Okx
{
    public static class Extensions
    {
        private static readonly Dictionary<Interval, OkxPeriod> _intervals =
            new Dictionary<Interval, OkxPeriod>()
            {
                { Interval.OneMinute, OkxPeriod.OneMinute },
                { Interval.ThreeMinutes, OkxPeriod.ThreeMinutes },
                { Interval.FiveMinutes, OkxPeriod.FiveMinutes },
                { Interval.FifteenMinutes, OkxPeriod.FifteenMinutes },
                { Interval.ThirtyMinutes, OkxPeriod.ThirtyMinutes },
                { Interval.OneHour, OkxPeriod.OneHour },
                { Interval.TwoHours, OkxPeriod.TwoHours },
                { Interval.FourHours, OkxPeriod.FourHours },
                { Interval.OneDay, OkxPeriod.OneDay },
                { Interval.OneWeek, OkxPeriod.OneWeek },
                { Interval.OneMonth, OkxPeriod.OneMonth }
            };

        public static OkxPeriod MapInterval(this Interval interval)
        {
            return _intervals.ContainsKey(interval) ? _intervals[interval] : throw new KeyNotFoundException();
        }

        public static IQuote ToQuote(this OkxCandlestick candlestick)
        {
            if (candlestick == null) throw new ArgumentNullException(nameof(candlestick));

            return new CustomQuote(candlestick.Low, candlestick.Open, candlestick.High, candlestick.Close,
                candlestick.TradingVolume, candlestick.Time);
        }

        public static StockTicker ToStockTicker(this OkxInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new StockTicker(instrument.Instrument, $"OKX {instrument.BaseCurrency}/{instrument.QuoteCurrency}",
                instrument.BaseCurrency, StockExchange.Okx, InstrumentType.Spot, new Currency(instrument.QuoteCurrency),
                    new LotFilter(instrument.LotSize), new PriceFilter(instrument.MinimumOrderSize));
        }
    }
}
