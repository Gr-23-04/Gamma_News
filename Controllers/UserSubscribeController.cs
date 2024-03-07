using Gamma_News.Data;
using Gamma_News.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Gamma_News.Controllers
{
    [Authorize] //user is authenticated
    public class UserSubscribeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        //public SubscriptionsController(ApplicationDbContext context, UserManager<User> userManager)
        //{ 
        //    _context = context;
        //    _userManager = userManager;

        //}
        public async Task<IActionResult> Indexshown()
        { 
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); // Prompt user to log in

            var subscriptions= await _context.Subscriptions
                .Where(s=> s.UserId == currentUser.Id)
                .Include(s => s.Article)  // Load the related articles
                .Select(s => s.Article) // Select only the articles
                .ToListAsync();
            return View(subscriptions);// Pass the articles to the view





        }
        //Implement a create action in the SubscriptionsController
        //that handles the logic when a user subscribes to an article.
        //This action will create a new Subscription instance linking
        //the user with the article.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() //handles the logic when a user subscribes to an article. This action will
                                      //create a new Subscription instance linking the user with the article.
        {
            return View();
        }
    }
}
