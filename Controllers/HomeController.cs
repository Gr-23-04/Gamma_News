using Gamma_News.Data;
using Gamma_News.Models;
using Gamma_News.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;




namespace Gamma_News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        private readonly UserManager<User> user;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IArticleService articleService)

        {
            _articleService = articleService;
            _logger = logger;
            _db = db;

        }

        public IActionResult Index()
        {
            var articles = _articleService.GetAllArticles().Result.ToList();
            return View(articles);
        }

        public IActionResult Local()
        {
            var articles = _articleService.GetAllArticles().Result.ToList();
            return View(articles);
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
