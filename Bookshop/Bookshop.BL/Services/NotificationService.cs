using Bookshop.BL.DTOs;
using Bookshop.BL.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.BL.Services
{
    public class NotificationService
    {
        public async void Send(SenderEmailDetails senderEmailDetails)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Bookshop", senderEmailDetails.SenderEmail));
            emailMessage.To.Add(new MailboxAddress("", senderEmailDetails.RecipientEmail));
            emailMessage.Subject = senderEmailDetails.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = senderEmailDetails.Message
            };

            using (var client2 = new SmtpClient())
            {
                await client2.ConnectAsync("smtp.gmail.com", 465, true);
                await client2.AuthenticateAsync(senderEmailDetails.SenderEmail, senderEmailDetails.SenderPassword);
                await client2.SendAsync(emailMessage);

                await client2.DisconnectAsync(true);
            }
        }

    }
}
