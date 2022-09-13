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
        [HttpPost("/accounts/signup")]
        public ActionResult<ClientReadDto> SignUp(ClientCreateDto client)
        {
            try
            {
                int? idOfAddedAccount = _clientService.SignUp(client);
                _logger.LogInformation($"Added new client with ID {idOfAddedAccount}");
                ClientReadDto signedUpClient = new ClientReadDto()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Email = client.Email,
                    Number = client.Number,
                };

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
        [HttpGet("/accounts/signin")]
        public ActionResult<ClientReadDto> SignIn(ClientCreateDto client)
        {
            _clientService.SignIn(client);
            return Ok();
        }
        [HttpGet("/accounts/signout")]
        public ActionResult<ClientReadDto> SignOut(ClientCreateDto client)
        {
            _clientService.SignOut(client);
            return Ok();
        }

        [HttpGet("/accounts/remove")]
        public ActionResult<ClientReadDto> RemoveAccount(ClientCreateDto client)
        {
            _clientService.Remove(client);
            return Ok();
        }

        [HttpGet("/accounts/change_password")]
        public ActionResult<ClientReadDto> ChangePassword(ClientCreateDto client)
        {
            _clientService.ChangePassword(client);
            return Ok();
        }
    }
}
