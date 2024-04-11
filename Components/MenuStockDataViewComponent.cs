using Gamma_News.Models;
using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    public class MenuStockDataViewComponent:ViewComponent
    {
        private readonly IStockDataService _stockDataService;

        public MenuStockDataViewComponent(IStockDataService stockDataService)
        {

            _stockDataService = stockDataService;
        }
        public IViewComponentResult Invoke(string region)
        {
            var data = _stockDataService.GetData(region) ?? Enumerable.Empty<StockData>();
            //data = new List<StockData>
            //{
            //    new StockData
            //    {
            //        Close = 2,
            //        Name = "Test",
            //        PercentChange = 0.2f,
            //        Symbol = "test"
            //    },
            //    new StockData
            //    {
            //        Close = 1,
            //        Name = "Test 2",
            //        PercentChange = -0.2f,
            //        Symbol = "test2"
            //    },
            //    new StockData
            //    {
            //        Close = 1,
            //        Name = "Test 2",
            //        PercentChange = -0.2f,
            //        Symbol = "test2"
            //    },
            //    new StockData
            //    {
            //        Close = 1,
            //        Name = "Test 2",
            //        PercentChange = -0.2f,
            //        Symbol = "test2"
            //    },
            //    new StockData
            //    {
            //        Close = 1,
            //        Name = "Test 2",
            //        PercentChange = -0.2f,
            //        Symbol = "test2"
            //    },
            //    new StockData
            //    {
            //        Close = 1,
            //        Name = "Test 2",
            //        PercentChange = -0.2f,
            //        Symbol = "test2"
            //    },
            //};
            return View("Index", data);
        }
        

    }
}
