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
        public InputModel Input { get; set; } = new InputModel();


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
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            Username = userName;

            if (Input == null)
            {
                Input = new InputModel();
            }

            IFormFile upfile = Input.profile_image;



            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                profile_image = upfile
            };

        }
        public async Task<string> upload_image_async(IFormFile input, User user)
        {
            var allowedFormats = new[] { "image/jpeg", "image/png", "image/gif", "image/webp", "image/bmp" };

            if (input == null || input.Length == 0)
            {
                throw new ArgumentException("No file was uploaded.");
            }

            if (input.Length > 5 * 1024 * 1024)
            {
                throw new ArgumentException("The image your trying to upload iss larger than 5MB");

            }

            if (!allowedFormats.Contains(input.ContentType))
            {
                throw new ArgumentException("Invalid file format. Only WEBP, BMP, JPEG, PNG, and GIF images are allowed.");
            }
            string blobName = $"{user.Id}_{input.FileName}";


            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient("newssitesprofilepics");
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await using (var stream = input.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
                stream.Close();

            }
            return blobClient.Uri.AbsoluteUri;
        }
#nullable enable
        public async Task<string?> get_profile_image(User user)

        {
            var profile_image = await _db.Users
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
            var profile_pic = get_profile_image(user);
            if (profile_pic == null || user.profile_image == "M18.685 19.097A9.723 9.723 0 0021.75 12c0-5.385-4.365-9.75-9.75-9.75S2.25 6.615 2.25 12a9.723 9.723 0 003.065 7.097A9.716 9.716 0 0012 21.75a9.716 9.716 0 006.685-2.653zm-12.54-1.285A7.486 7.486 0 0112 15a7.486 7.486 0 015.855 2.812A8.224 8.224 0 0112 20.25a8.224 8.224 0 01-5.855-2.438zM15.75 9a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0z")
            {
                user.profile_image = "M18.685 19.097A9.723 9.723 0 0021.75 12c0-5.385-4.365-9.75-9.75-9.75S2.25 6.615 2.25 12a9.723 9.723 0 003.065 7.097A9.716 9.716 0 0012 21.75a9.716 9.716 0 006.685-2.653zm-12.54-1.285A7.486 7.486 0 0112 15a7.486 7.486 0 015.855 2.812A8.224 8.224 0 0112 20.25a8.224 8.224 0 01-5.855-2.438zM15.75 9a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0z";
            }
            else
            {
                user.profile_image = user.profile_image;
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

            if (Input == null || Input.profile_image == null)
            {
                // Handle the case where InputModel or profile_image is null
                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
                return RedirectToPage();
            }
            else
            {

                var imageUrl = await upload_image_async(Input.profile_image, user);

                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
                return RedirectToPage();

            }
        }
    }
}
