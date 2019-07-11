using CoinMarketCapAdapter.Contracts;
using CoinMarketCapAdapter.Entities;
using Knabto.Contracts;
using Knabto.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knabto.Services
{
    public class CurrencyService : ICurrencyService
    {
        readonly ICoinMarketCapService _coinMarketCapService;
        readonly ICalculator _calculator;

        public CurrencyService(ICoinMarketCapService coinMarketCapService, ICalculator calculator)
        {
            _coinMarketCapService = coinMarketCapService;
            _calculator = calculator;
        }

        public List<CrytoCurrency> GetCryptoCurrencies(string currency, decimal amount)
        {
            var coinMarketCapCryptoResponse = _coinMarketCapService.GetCurrencyInformation(currency).Result;

            var crytoCurrencies = new List<CrytoCurrency>();

            if (coinMarketCapCryptoResponse.data == null)
                return crytoCurrencies;

            foreach (var item in coinMarketCapCryptoResponse.data.Where(d => d.Name.ToUpper() == "BITCOIN"))
            {
                if (item != null)
                {
                    var json = JsonConvert.SerializeObject(item.Quote);

                    string price = TryGetPriceFromJson(json, currency);

                    crytoCurrencies.Add(GetCrytoCurrency(item, Convert.ToDecimal(price), amount, currency));
                }
            };

            return crytoCurrencies;
        }

        string TryGetPriceFromJson(string json, string currency) =>
            json.Contains("price") ? JObject.Parse(json)[currency]["price"].ToString() : "0";

        CrytoCurrency GetCrytoCurrency(Data data, decimal price, decimal amount, string currency)
        {
            return new CrytoCurrency
            {
                Name = data.Name,
                Price = _calculator.Multiply(price, amount),
                Currency = currency,
                Amount = amount
            };
        }
    }
}
