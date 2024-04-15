using Gamma_News.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace Gamma_News.Services;

public class EmailSender : IEmailSender
{
    private readonly UserManager<User> _user;

    public EmailSender(UserManager<User> user)
    {
        _user = user;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {


    }

}
