using Bookshop.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bookshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpPost("/add/{id}")]
        public ActionResult<List<Book>> AddToCart(int id)
        {
            return Ok();
        }
        [HttpDelete("/remove/{id}")]
        public ActionResult<List<Book>> DeleteFromCart(int id)
        {
            return Ok();
        }
        [HttpPost("/confirm")]
        public ActionResult<List<Book>> ConfirmOrder()
        {
            return Ok();
        }
    }
}
