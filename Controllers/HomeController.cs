using Gamma_News.Data;
using Gamma_News.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Gamma_News.Models.ViewModels;




namespace Gamma_News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private object? articleId;
		
		private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger)

        {
            _logger = logger;
            
        }

        public Task<IEnumerable<object>> Index()
        {
            var articles = _db.Articles.ToList(); // Fetch articles from database
            return articles; // Pass articles to view
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
