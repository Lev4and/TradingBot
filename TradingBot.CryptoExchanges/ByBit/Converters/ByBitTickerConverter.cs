﻿using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.ByBit.Converters
{
    public class ByBitTickerConverter : ITickerConverter
    {
        public string Convert(Symbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return $"{input.InstrumentCode}{input.Currency?.Name ?? ""}";
        }
    }
}
