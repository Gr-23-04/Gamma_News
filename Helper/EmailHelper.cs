using Gamma_News.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;

namespace Gamma_News.Helper
{
    public class EmailHelper : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _user;
        private string _content;


        public EmailHelper(IConfiguration configuration, UserManager<User> user)
        {
            _configuration = configuration;
            _user = user;

        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string response = "";

            var message = new MimeMessage();

            message.Sender = MailboxAddress.Parse(_configuration["SenderEmail"]);

            message.Sender.Name = _configuration["SenderName"];

            message.To.Add(MailboxAddress.Parse(email));

            message.From.Add(message.Sender);

            message.Subject = subject;

            _content = htmlMessage;

            //We will say we are sending HTML. But there are options for plaintext etc.

            message.Body = new TextPart(TextFormat.Html) { Text = _content };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!

            using (var emailClient = new SmtpClient())

            {

                try

                {

                    //The last parameter here is to use SSL (Which you should!)

                    emailClient.Connect(_configuration["SmtpServer"], Convert.ToInt32(_configuration["SmtpPort"]), true);

                }

                catch (SmtpCommandException ex)

                {

                    response = "Error trying to connect:" + ex.Message + " StatusCode: " + ex.StatusCode;

                    await Task.FromResult(response);

                }

                catch (SmtpProtocolException ex)

                {

                    response = "Protocol error while trying to connect:" + ex.Message;

                    await Task.FromResult(response);

                }

                //Remove any OAuth functionality as we won't be using it.

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_configuration["SmtpUsername"], _configuration["SmtpPassword"]);

                try

                {

                    emailClient.Send(message);

                }

                catch (SmtpCommandException ex)

                {

                    response = "Error sending message: " + ex.Message + " StatusCode: " + ex.StatusCode;

                    switch (ex.ErrorCode)

                    {

                        case SmtpErrorCode.RecipientNotAccepted:

                            response += " Recipient not accepted: " + ex.Mailbox;

                            break;

                        case SmtpErrorCode.SenderNotAccepted:

                            response += " Sender not accepted: " + ex.Mailbox;

                            Console.WriteLine("\tSender not accepted: {0}", ex.Mailbox);

                            break;

                        case SmtpErrorCode.MessageNotAccepted:

                            response += " Message not accepted.";

                            break;

                    }

                }

                emailClient.Disconnect(true);

            }

            await Task.CompletedTask;
        }
    }
}