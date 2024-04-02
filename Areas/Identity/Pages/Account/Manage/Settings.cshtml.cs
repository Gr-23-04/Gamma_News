using Gamma_News.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma_News.Areas.Identity.Pages.Account.Manage
{
    public class SettingsModel : PageModel
    {

        private readonly UserManager<User> _userManager;
        private readonly ILogger<SettingsModel> _logger;
        public SettingsModel(
            UserManager<User> userManager,
            ILogger<SettingsModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }

        [TempData]
        public string StatusMessage { get; set; }
    }

}