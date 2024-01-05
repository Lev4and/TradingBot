using Bybit.Net.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace TradingBot.HttpClients.ByBit
{
    internal static class Configure
    {
        public static void AddByBitHttpClients(this IServiceCollection services)
        {
            services.AddSingleton(factory => new BybitRestClient()); 
        }
    }
}
