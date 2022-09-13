using Bookshop.BL.DTOs;
using Bookshop.BL.Models;
using Bookshop.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Bookshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        public CartController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/cart")]
        public ActionResult<List<OrderItemDto>> SeeCart()
        {
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                List<BookDto> books = JsonConvert.DeserializeObject<List<BookDto>>(HttpContext.Session.GetString("cart"));
                return Ok(books);
            }
            return Ok();
        }
        [HttpPost("/cart/add/{id}")]
        public ActionResult<List<BookDto>> AddToCart(BookDto book)
        {
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                List<BookDto> books = JsonConvert.DeserializeObject<List<BookDto>>(HttpContext.Session.GetString("cart"));
                books.Add(book);
                string serializedBooks = JsonConvert.SerializeObject(books);
                HttpContext.Session.SetString("cart", serializedBooks);
            }
            else
            {
                string serializedBooks = JsonConvert.SerializeObject(new List<BookDto>() { book} );
                HttpContext.Session.SetString("cart", serializedBooks);
            }
            return Ok();
        }
        [HttpDelete("/cart/remove/{id}")]
        public ActionResult<List<BookDto>> DeleteFromCart(BookDto book)
        {
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                List<BookDto> books = JsonConvert.DeserializeObject<List<BookDto>>(HttpContext.Session.GetString("cart"));
                books.Remove(book);
                string serializedBooks = JsonConvert.SerializeObject(books);
                HttpContext.Session.SetString("cart", serializedBooks);
            }
            return Ok();
        }
        [HttpPost("/cart/confirm")]
        public ActionResult<List<BookDto>> ConfirmOrder()
        {
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                List<BookDto> books = JsonConvert.DeserializeObject<List<BookDto>>(HttpContext.Session.GetString("cart"));
                return Ok(books);
            }
            return Ok();
        }
    }
}
