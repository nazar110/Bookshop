using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Bookshop.BL.Models;
using Bookshop.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly PageSettingsService _pageSettingsService;
        private readonly BookService _bookService;
        public BooksController(ILogger<BooksController> logger, PageSettingsService pageSettingsService, BookService bookService)
        {
            _logger = logger;
            _pageSettingsService = pageSettingsService;
            _bookService = bookService;
        }

        [HttpGet("/books")]
        public ActionResult<List<BookDto>> GetBooks()
        {
            HttpContext.Request.Query.TryGetValue("pageNum", out StringValues pageValue);
            HttpContext.Request.Query.TryGetValue("orderBy", out StringValues orderValue);
            HttpContext.Request.Query.TryGetValue("filterBy", out StringValues filterValue);
            HttpContext.Request.Query.TryGetValue("searchBy", out StringValues phraseForSearchValue);
            Int32.TryParse(pageValue.ToString(), out int pageNum);
            string orderParam = orderValue.ToString();
            string filterParam = filterValue.ToString();
            string phraseForSearch = phraseForSearchValue.ToString();
            _pageSettingsService.BooksDetails = _bookService.GetAll();
            List<BookDto> requestedBooks = _pageSettingsService.Configure(pageNum, 2, orderParam, filterParam, phraseForSearch);
            if (requestedBooks == null)
            {
                return BadRequest();
            }

            return Ok(requestedBooks);
        }
        [HttpGet("/books/{id}")]
        public ActionResult<List<BookDto>> GetBookBy(int id)
        {
            BookDto bookDto = _bookService.GetBy(id);
            if (bookDto == null)
            {
                return NotFound();
            }
            return Ok(bookDto);
        }
    }
}
