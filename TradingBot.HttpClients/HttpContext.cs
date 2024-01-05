using Binance.Net.Clients;
using Bybit.Net.Clients;
using OKX.Api;

namespace TradingBot.HttpClients
{
    public class HttpContext
    {
        public OKXRestApiClient Okex { get; }
        
        public BybitRestClient ByBit { get; }

        public BinanceRestClient Binance { get; }

        public HttpContext(OKXRestApiClient okex, BybitRestClient byBit, BinanceRestClient binance)
        {
            Okex = okex;
            ByBit = byBit;
            Binance = binance;
        }
    }
}
