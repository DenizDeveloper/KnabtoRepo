using System;

namespace CoinMarketCapAdapter.Entities
{
    public class Data
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public object Quote { get; set; }
    }
}