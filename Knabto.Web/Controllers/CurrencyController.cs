using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knabto.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Knabto.Web.Controllers
{
    public class CurrencyController : Controller
    {
        readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public IActionResult StartPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartPage(string currency, decimal amount)
        {
            if (amount < 0)
                return View();
            
            var cryptoCurrencies = _currencyService.GetCryptoCurrencies(currency, amount);
            return View(cryptoCurrencies);
        }
    }
}