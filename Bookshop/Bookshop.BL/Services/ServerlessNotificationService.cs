using Bookshop.BL.DTOs;
using Bookshop.BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.BL.Services
{
    public class ServerlessNotificationService
    {
        public async void Send(SenderEmailDetails senderEmailDetails)
        {
            string uri = "https://c3kwm5suyb4qnmr2zzyzfhg3hi0jhbgd.lambda-url.us-east-1.on.aws";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage reqMes = new HttpRequestMessage(HttpMethod.Post, uri);
            object reqBody = new
            {
                SenderEmail = senderEmailDetails.SenderEmail,
                SenderPassword = senderEmailDetails.SenderPassword,
                RecipientEmail = senderEmailDetails.RecipientEmail,
                Subject = senderEmailDetails.Subject,
                Message = senderEmailDetails.Message
            };
            string body = JsonConvert.SerializeObject(reqBody);
            reqMes.Content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage respMes = await httpClient.SendAsync(reqMes);
            if (respMes.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Failed to send notification via AWS");
            }
        }
    }
}
