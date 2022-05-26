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
                ClientReadDto signedUpclient = new ClientReadDto()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Email = client.Email,
                    Number = client.Number,
                };

                return Ok(signedUpclient);
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
    }
}
