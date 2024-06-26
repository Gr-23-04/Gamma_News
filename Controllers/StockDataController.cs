﻿using Gamma_News.Models;
using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Gamma_News.Controllers
{
    public class StockDataController : Controller
    {
        private readonly IStockDataService _stockDataService;

        public StockDataController(IStockDataService stockDataService)
        {
            _stockDataService = stockDataService;
        }
        public IActionResult Index(string region)
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
            //};
            return View(data);
            
        }
    }
}
