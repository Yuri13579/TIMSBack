using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using TIMSBack.Domain.Entities;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TIMSBack.Infrastructure.Services
{
   
    public class EmailService
    {
        //public IConfiguration Configuration { get; }
        //IConfiguration configuration
        //Configuration = configuration;

        public EmailService()
        {
            
        }


        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {

                var emailMessage = new MimeMessage();
                
                emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                var gmailClient = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(GlobalVariables.UserName, GlobalVariables.Password)
                };
                await gmailClient.SendMailAsync(new MailMessage
                {
                    Body = message,
                    Subject = subject,
                    From = new MailAddress(GlobalVariables.UserName),
                    To = { new MailAddress(email) }

                });


                //using (var client = new SmtpClient())
                //{
                //    await client.ConnectAsync(GlobalVariables.Host, 587, true);
                //    await client.AuthenticateAsync(GlobalVariables.UserName, GlobalVariables.Password);
                //    await client.SendAsync(emailMessage);

                //    await client.DisconnectAsync(true);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}
