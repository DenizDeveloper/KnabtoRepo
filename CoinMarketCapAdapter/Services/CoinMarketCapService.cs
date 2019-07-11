using CoinMarketCapAdapter.Contracts;
using CoinMarketCapAdapter.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCapAdapter.Services
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        public static HttpClient Client()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "fa671cd3-3e28-46f2-81f3-f9068f0a980f");
            return client;
        }

        public Task<CoinMarketCapCryptoResponse> GetCurrencyInformation(string currency) =>
            GetCurrencyInformationAsync(currency);

        static async Task<CoinMarketCapCryptoResponse> GetCurrencyInformationAsync(string currency)
        {
            var coinMarketCapCryptoResponseJson = new CoinMarketCapCryptoResponse();
            HttpResponseMessage response = await Client().GetAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?convert=" + currency);
            if (response.IsSuccessStatusCode)
            {
                var coinMarketCapCryptoResponseAsString = await response.Content.ReadAsStringAsync();
                coinMarketCapCryptoResponseJson = JsonConvert.DeserializeObject<CoinMarketCapCryptoResponse>(coinMarketCapCryptoResponseAsString);
            }

            return coinMarketCapCryptoResponseJson;
        }
    }
}
