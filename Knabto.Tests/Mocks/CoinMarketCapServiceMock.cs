using CoinMarketCapAdapter.Contracts;
using CoinMarketCapAdapter.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knabto.Tests.Mocks
{
    internal class CoinMarketCapServiceMock : ICoinMarketCapService
    {
        public Task<CoinMarketCapCryptoResponse> GetCurrencyInformation(string currency) =>
            GetCurrencyInformationAsync(currency);

        static async Task<CoinMarketCapCryptoResponse> GetCurrencyInformationAsync(string currency)
        {
            return new CoinMarketCapCryptoResponse
            {
                data = new List<Data>
                {
                    new Data
                    {
                        Name = "Bitcoin",
                        Quote = new object(),
                        Symbol = "BTC"
                    }
                }
            };
        }
    }
}
