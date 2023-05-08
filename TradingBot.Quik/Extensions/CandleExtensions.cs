﻿using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Extensions
{
    public static class CandleExtensions
    {
        public static IQuote ToQuote(this Candle candle)
        {
            if (candle == null) throw new ArgumentNullException(nameof(candle));

            return new CustomQuote(candle.Low, candle.Open, candle.High, candle.Close, candle.Volume,
                candle.Datetime.ToDateTime());
        }
    }
}