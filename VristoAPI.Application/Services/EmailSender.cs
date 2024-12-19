using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MimeKit.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;

namespace VristoAPI.Application.Services
{
 

    public  class EmailSender
    {
        private  readonly IConfiguration config;

        public EmailSender(IConfiguration config)
        {
            this.config = config;
        }

        public  async Task<bool> SendEmail(string RecieverEmail,string ViewName)
        {
            
            try
            {
                var email = new MimeMessage()
                {
                    Sender = MailboxAddress.Parse(config.GetSection("EmailSettings").GetRequiredSection("EmailSender").Value.ToString()),
                    Subject = config.GetSection("EmailSettings").GetRequiredSection("Subject").Value.ToString()


                };
                email.To.Add(MailboxAddress.Parse(RecieverEmail));
                // var builder = new BodyBuilder();
                var content = "";
                if (File.Exists(Directory.GetCurrentDirectory() + "/EmailTemplates/" + ViewName))
                {


                     content = File.ReadAllText(Directory.GetCurrentDirectory() + "/EmailTemplates/" + ViewName).ToString();

                }
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = content

                };
             
             

                email.Body = bodyBuilder.ToMessageBody();


                email.From.Add(new MailboxAddress("Vristo WebSite", config.GetSection("EmailSettings").GetRequiredSection("EmailSender").Value.ToString()));



                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(config.GetSection("EmailSettings").GetRequiredSection("host").Value.ToString(), int.Parse(config.GetSection("EmailSettings").GetRequiredSection("Port").Value.ToString()), false);
                    smtp.Authenticate(config.GetSection("EmailSettings").GetRequiredSection("EmailSender").Value.ToString(), config.GetSection("EmailSettings").GetRequiredSection("Password").Value.ToString());
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
