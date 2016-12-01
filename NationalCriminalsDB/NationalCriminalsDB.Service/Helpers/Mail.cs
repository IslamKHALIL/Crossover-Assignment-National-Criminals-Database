using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NationalCriminalsDB.Service.Helpers
{
    public interface IMail
    {
        Task SendEmailAsync(MailMessage mail);
        Task SendEmailAsync(string recipient, IEnumerable<FileInfo> attachments = null);
    }

    internal class Mail : IMail
    {
        private readonly IConfiguration config;

        public Mail(IConfiguration config)
        {
            this.config = config;
        }

        public async Task SendEmailAsync(string recipient, IEnumerable<FileInfo> attachments = null)
        {
            if (string.IsNullOrEmpty(recipient) || !Regex.IsMatch(recipient, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                throw new ArgumentException("Bad recipient email.");

            using (var mail = new MailMessage(config.GmailId, recipient)
            {
                IsBodyHtml = true,
                Subject = "Criminal records search results",
                Body = (attachments != null && attachments.Count() > 0) ? "Kindly find attached the profiles of your search request" : "Sorry we couldn't find any profile with the criterias in your search",
            })
            {
                if (attachments != null && attachments.Count() > 0)
                {
                    foreach (var file in attachments)
                        mail.Attachments.Add(new Attachment(file.FullName));
                }
                await SendEmailAsync(mail);
            }
        }

        public Task SendEmailAsync(MailMessage mail)
        {
            if (mail == null)
                throw new NullReferenceException("MailMessage object cannot be null.");

            return Task.Run(() =>
            {
                using (var client = new SmtpClient()
                {
                    Host = config.SMTPHost,
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(config.GmailId, config.GmailPswrd),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                })
                {
                    client.Send(mail);
                }
            });
        }
    }
}
