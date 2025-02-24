using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Portfolio.Business.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class MailServices : IMail
    {
        private readonly MailSettings _mailSettings;

        public MailServices(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailVModel mailVModel)
        {


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));
            message.To.Add(new MailboxAddress(_mailSettings.DispalyReciverName, _mailSettings.ReciverEmail));
            message.Subject = mailVModel.Subject;
            message.Body = new TextPart("plain") { Text = mailVModel.Body };

            message.ReplyTo.Add(new MailboxAddress(mailVModel.Name, mailVModel.Email));

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.SslOnConnect);
                client.Authenticate(_mailSettings.Email, _mailSettings.Password); // استخدم App Password هنا
                client.Send(message);
                client.Disconnect(true);
            }



            //var email = new MimeMessage
            //{

            //    Sender = MailboxAddress.Parse(_mailSettings.Email),
            //    Subject = "omar",

            //};

            //email.To.Add(MailboxAddress.Parse(_mailSettings.ReciverEmail));
            ////  email.ReplyTo.ToList(new MailboxAddress( mailVModel.MailTo);

            //var builder = new BodyBuilder();

            //if (mailVModel.Attachments != null)
            //{
            //    byte[] fileBytes;

            //    foreach (var attachment in mailVModel.Attachments)
            //    {
            //        if (attachment.Length > 0)
            //        {
            //            using var ms = new MemoryStream();
            //            attachment.CopyTo(ms);
            //            fileBytes = ms.ToArray();
            //            builder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));

            //        }
            //    }

            //}

            //builder.HtmlBody = mailVModel.Body;
            //email.Body = builder.ToMessageBody();
            //email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

            //smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            //await smtp.SendAsync(email);

        }
    }
}
