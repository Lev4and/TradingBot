﻿namespace TradingBot.HttpClients.Core.HttpResponseReaders
{
    public class BaseHttpResponseReader : IHttpResponseReader
    {
        public async Task<string> ReadAsync(HttpResponseMessage response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
