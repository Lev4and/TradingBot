﻿using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.Core.Converters.Exchange
{
    public interface IOrderBookConverter<TOrderBook> : IConverter<TOrderBook, OrderBook>
    {

    }
}