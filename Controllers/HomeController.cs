using Gamma_News.Data;
using Gamma_News.Models;
using Gamma_News.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;




namespace Gamma_News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        private readonly UserManager<User> user;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IArticleService articleService,UserManager<User>userManager )

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
            return View();
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

        public IActionResult Subscribe()
        {

            if (_userManager.GetUserId(User).Any())
            {
                var user = _userManager.GetUserName(User);
                if (_db.Subscriptions.Where(x => x.UserName == user).Any())
                {
                   
                   ViewBag.Message = "You already have a subscription, please enter 'My Account - Subscriptions' for further details.";
                    
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Subscribe(int plan)
        {

            Subscription sub = new Subscription();
            sub.SubscriptionTypeId = plan;
            sub.Created = DateTime.Now;
            sub.User = _db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            sub.Active = true;


            if (plan == 1)
            {
                sub.Price = 5;
                sub.Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                sub.Price = 50;
                sub.Expires = DateTime.Now.AddYears(1);
            }

            sub.PaymentComplete = true;
            _db.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            _db.SaveChanges();


            return RedirectToAction("ThankYou");

        }

        public IActionResult ThankYou()
        {
            return View();
        }



    }
}
