using Knabto.Contracts;
using Knabto.Services;
using Knabto.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Knabto.Tests
{
    public class CurrencyServiceTest
    {
        [Fact]
        public void GetCryptoCurrenciesTest()
        {
            //Arange
            ICurrencyService currencyService = new CurrencyService(new CoinMarketCapServiceMock(), new CalculatorMock());

            //Act
            var currencies = currencyService.GetCryptoCurrencies("USD", 20).FirstOrDefault();

            //Assert
            Assert.True(currencies != null);
            Assert.True(currencies.Amount == 20);
            Assert.True(currencies.Price == 12);
            Assert.True(currencies.Name == "Bitcoin");
        }
    }
}
