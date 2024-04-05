// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Azure.Storage.Blobs;
using Gamma_News.Data;
using Gamma_News.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gamma_News.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<User> _signInManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public IndexModel(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _db = applicationDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration["AzureWebJobsStorage"]);
        }

        public string Username { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>


        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Profile picture")]
            public IFormFile profile_image { get; set; }
            public string FileName { get; set; }
            public string image_link { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var image_Link = await get_profile_image(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                image_link = image_Link,

            };
        }
        public async Task<string> upload_image_async(IFormFile file, User user)
        {
            var allowedFormats = new[] { "image/jpeg", "image/png", "image/gif", "image/webp", "image/bmp" };

            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file was uploaded.");
            }

            if (!allowedFormats.Contains(file.ContentType))
            {
                throw new ArgumentException("Invalid file format. Only WEBP, BMP, JPEG, PNG, and GIF images are allowed.");
            }
            string blobName = $"{user.Id}_{file.FileName}";


            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient("newssitesprofilepics");
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await using (var stream = file.OpenReadStream())
            {
                blobClient.Upload(stream);

            }
            return blobClient.Uri.AbsoluteUri;
        }
#nullable enable
        public async Task<string?> get_profile_image(User user)

        {
            var profile_image = await _userManager.Users
                .Where(u => u.Id == user.Id)
                .Select(u => u.profile_image)
                .FirstOrDefaultAsync();

            return profile_image;

        }

#nullable disable
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }




            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
