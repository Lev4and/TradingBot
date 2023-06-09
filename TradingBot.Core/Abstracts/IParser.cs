﻿namespace TradingBot.Core.Abstracts
{
    public interface IParser<TInput, TOutput>
    {
        TOutput Parse(TInput input);
    }
}
