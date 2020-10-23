using CorporateArena.Domain;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Presentation
{
    public class EmailSender : IEmailSender
    {

        private readonly string _SendgridKey;
        public EmailSender(string SendgridKey)
        {
            _SendgridKey = SendgridKey;
        }



        //public Task Execute(string apiKey, string subject, string message, List<string> emails)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("noreply@domain.com", "Bekenty Jean Baptiste"),
        //        Subject = subject,
        //        PlainTextContent = message,
        //        HtmlContent = message
        //    };

        //    foreach (var email in emails)
        //    {
        //        msg.AddTo(new EmailAddress(email));
        //    }

        //    Task response = client.SendEmailAsync(msg);
        //    return response;
        //}


        public async Task ActivateAccountAsync(string username,string email,int id)
        {
            var client = new SendGridClient(_SendgridKey);
            var from = new EmailAddress("tkolawole@inspirecoders.com");
            var subject = "New Account Activation";
            var to = new EmailAddress(email, username);
            var plainTextContent = "<a href='https://localhost:44369/api/user/Activate/" + id + "'>Activate Account</a>";
            var htmlContent = "<a href='https://localhost:44369/api/user/Activate/"+id+"'>Activate Account</a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendUserMessage(ContactEmail email)
        {
            var client = new SendGridClient(_SendgridKey);
            var from = new EmailAddress(email.Email, email.Username);
            var subject = email.Subject;
            var to = new EmailAddress("kolawoletoheeb18@yahoo.com");
            var plainContent = email.Message;
            var htmlContent = email.Message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
