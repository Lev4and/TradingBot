using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;
using TradingBot.Quik;

namespace TradingBot.TradeAdapters.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
            services.AddQuik();
        }
    }
}
