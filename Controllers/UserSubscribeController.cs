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

        public UserSubscribeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        //public async Task<IActionResult> Indexshown()
        //{ 
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    if (currentUser == null)
        //        return Challenge(); // Prompt user to log in

        //    var subscriptions= await _context.Subscriptions
        //        .Where(s=> s.UserId == currentUser.Id)
        //        .Include(s => s.Article)  // Load the related articles
        //        .Select(s => s.Article) // Select only the articles
        //        .ToListAsync();
        //    return View(subscriptions);// Pass the articles to the view

        //}
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

        //private readonly SignInManager<User>? _signInManager;
        //public UserSubscribeController(SignInManager<User> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        //public ActionResult Login(string returnUrl)
        //{ 
        //   ViewBag.ReturnUrl = returnUrl;
        //   return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<Actionresult> Login(LoginViewModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);

        //    }

        //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

        //    if
        //}
        //[HttpGet]
        //public IActionResult Resgister()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User { Username = model.Username, Email = model.Email, Password = model.Password }; // Consider hashing the password
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index", "Home");


        //    }

        //    return View(model);
        //}






        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Implement your login logic here. For simplicity, this example does not include actual sign-in operations.
            // In a real application, you might use SignInManager or your custom logic to sign in the user.

            // Redirect to home or another page upon successful login
            if (username == "user" && password == "password")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

    }
}
