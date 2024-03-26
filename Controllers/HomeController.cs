using Gamma_News.Data;
using Gamma_News.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;




namespace Gamma_News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private object? articleId;

        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)

        {
            _db = db;
            _logger = logger;

        }

        public async Task<IEnumerable<object>> Index()
        {
            var articles = await _db.Articles.ToListAsync();
            return articles;
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Get article data 
        public async Task<IActionResult> GetArticle()
        {
            var articles = await _db.Articles
                .OrderByDescending(a => a.Id)
                .Take(5)
                .ToListAsync();
            ViewData["Articles"] = articles;

            return View();

        }


    }
}
