using Gamma_News.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Controllers
{

    public class UserSubscribeController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //public object Roles { get; private set; }

        public UserSubscribeController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> CreateUser() //everytime go to /Home/CreateUser, the user accound will be removed and created again.
        {
            var existingUser = await _userManager.FindByNameAsync("user@localhost");
            if (existingUser is not null)
            {
                await _userManager.DeleteAsync(existingUser);

            }
            var user = new IdentityUser
            {
                UserName = "user@localhost",
                Email = "user@localhost",
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, "Abc&123");
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, new[] { Roles.Customer, Roles.Editor });
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> CreateRoles()
        {
            var adminExists = await _roleManager.RoleExistsAsync(Roles.Admin);
            if (!adminExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            var editorExists = await _roleManager.RoleExistsAsync(Roles.Editor);
            if (!editorExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Editor));
            }

            var customerExists = await _roleManager.RoleExistsAsync(Roles.Customer);
            if (!customerExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Customer));
            }

            return RedirectToAction(nameof(Index));
        }



        [Authorize] //user is authenticated
        public async Task<IActionResult> UserInfo()
        {
            var user = _userManager.GetUserAsync(User);
            if (user is null)
            {
                return NotFound();

            }
            return View();

        }


        //private readonly ApplicationDbContext _context;
        //private readonly UserManager<User> _userManager;

        //public SubscriptionsController(ApplicationDbContext context, UserManager<User> userManager)
        //{
        //    _context = context;
        //    _userManager = userManager;

        //}
        //public async Task<IActionResult> Indexshown()
        //{
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    if (currentUser == null)
        //        return Challenge(); // Prompt user to log in

        //    var subscriptions = await _context.Subscriptions
        //        .Where(s => s.UserId == currentUser.Id)
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
    }
}
