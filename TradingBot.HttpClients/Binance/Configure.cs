using Binance.Net.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace TradingBot.HttpClients.Binance
{
    internal static class Configure
    {
        public static void AddBinanceHttpClients(this IServiceCollection services)
        {
            services.AddSingleton(factory => new BinanceRestClient());
        }
    }
}
