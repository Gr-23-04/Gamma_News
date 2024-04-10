using Gamma_News.Models;

namespace Gamma_News.Services
{
    public interface IStockDataService
    {
        IEnumerable<StockData> GetData(string region = "US");
    }
}
