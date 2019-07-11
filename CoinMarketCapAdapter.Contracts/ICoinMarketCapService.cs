using CoinMarketCapAdapter.Entities;
using System.Threading.Tasks;

namespace CoinMarketCapAdapter.Contracts
{
    public interface ICoinMarketCapService
    {
        Task<CoinMarketCapCryptoResponse> GetCurrencyInformation(string currency);
    }
}
