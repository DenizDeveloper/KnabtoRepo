using CoinMarketCapAdapter.Entities;
using Knabto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knabto.Contracts
{
    public interface ICurrencyService
    {
        List<CrytoCurrency> GetCryptoCurrencies(string currency, decimal amount);
    }
}
