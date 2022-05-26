using Bookshop.BL.DTOs;
using Bookshop.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly ClientService _clientService;
        private readonly NotificationService _notificationService;
        private readonly ServerlessNotificationService _serverlessNotificatiohService;
        public AccountsController(ILogger<BooksController> logger, ClientService clientService,
            NotificationService notificationService, ServerlessNotificationService serverlessNotificatiohService)
        {
            _logger = logger;
            _clientService = clientService;
            _notificationService = notificationService;
            _serverlessNotificatiohService = serverlessNotificatiohService;
        }
        [HttpPost("/signup")]
        public ActionResult<ClientReadDto> SignUp(ClientCreateDto client)
        {
            try
            {
                int? idOfAddedAccount = _clientService.SignUp(client);
                _logger.LogInformation($"Added new cliend with ID {idOfAddedAccount}");
                ClientReadDto signedUpClient = new ClientReadDto()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Email = client.Email,
                    Number = client.Number,
                };
                BL.Models.SenderEmailDetails senderEmailDetails = new BL.Models.SenderEmailDetails()
                {
                    SenderEmail = "course.project.bookstore@gmail.com",
                    SenderPassword = "dcthtlevu",
                    RecipientEmail = signedUpClient.Email,
                    Subject = "Tom from Bookshop",
                    Message = $"Hi, {signedUpClient.Name} {signedUpClient.Surname}! You were signed up successfully."
                };
                //_notificationService.Send(senderEmailDetails);
                senderEmailDetails.Subject = "Tom from Bookshop (Serverless)";
                _serverlessNotificatiohService.Send(senderEmailDetails);
                return Ok(signedUpClient);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new 
                    { 
                        Error = ex.Message, 
                        StackTrace = ex.StackTrace
                    });
            }
        }
        [HttpGet("/signin")]
        public ActionResult<ClientReadDto> SignIn(ClientCreateDto client)
        {
            return Ok();
        }
        [HttpGet("/signout")]
        public ActionResult<ClientReadDto> SignOut(ClientCreateDto client)
        {
            return Ok();
        }
    }
}
