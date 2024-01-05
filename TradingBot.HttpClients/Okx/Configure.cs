using Microsoft.Extensions.DependencyInjection;
using OKX.Api;

namespace TradingBot.HttpClients.Okx
{
    internal static class Configure
    {
        public static void AddOkxHttpClients(this IServiceCollection services)
        {
            //OKXRestApiClientOptions.Default.UnifiedApiOptions.BaseAddress = "https://www.okx.cab";
            
            services.AddSingleton(factory => new OKXRestApiClient(new OKXRestApiClientOptions { BaseAddress = "https://www.okx.cab" }));
        }
    }
}
