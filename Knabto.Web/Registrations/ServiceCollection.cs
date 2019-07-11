using CoinMarketCapAdapter.Contracts;
using CoinMarketCapAdapter.Services;
using Knabto.Contracts;
using Knabto.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knabto.Web.Registrations
{
    public static class ServiceCollection
    {
        public static IServiceCollection Services(IServiceCollection services)
        {
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<ICoinMarketCapService, CoinMarketCapService>();
            services.AddSingleton<ICalculator, Calculator>();

            return services;
        }
    }
}
