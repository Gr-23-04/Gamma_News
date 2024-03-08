using Gamma_News.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gamma_News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private object? articleId;

        public HomeController( ILogger<HomeController> logger )
        {
            _logger = logger;
        }

        public IActionResult Index( )
        {
            //Using ViewData or ViewBag
         
            // Assuming 'articleId' is the ID of the article you want to subscribe to
            ViewData["ArticleId"] = articleId;
            // Or using ViewBag
            //ViewBag.ArticleId = articleId;

            return View( );
        }






        public IActionResult Privacy( )
        {    
            return View();
        }
                                                                                                                                                                                                                                                                  
        [ResponseCache( Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true )]
        public IActionResult Error( )
        {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }


        //from video'identity User-role manager'
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

        }

        public async Task<IActionResult> CreateUser()
        {
            var user = new User
            {
                UserName = "user@localhost",
                Email = "user@localhost",
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, "Abc&123");
            if (result.Succeeded) 
            { 
               return RedirectToAction(nameof(Index));
            }
            return View();
        }

       
    }
}
                                                            