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
        public BooksController(ILogger<BooksController> logger, PageSettingsService pageSettingsService)
        {
            _logger = logger;
            _pageSettingsService = pageSettingsService;
        }

        [HttpGet("/books")]
        public ActionResult<List<Book>> GetBooks()
        {
            HttpContext.Request.Query.TryGetValue("pageNum", out StringValues pageValue);
            HttpContext.Request.Query.TryGetValue("orderBy", out StringValues orderValue);
            HttpContext.Request.Query.TryGetValue("filterBy", out StringValues filterValue);
            HttpContext.Request.Query.TryGetValue("searchBy", out StringValues phraseForSearchValue);
            Int32.TryParse(pageValue.ToString(), out int pageNum);
            string orderParam = orderValue.ToString();
            string filterParam = filterValue.ToString();
            string phraseForSearch = phraseForSearchValue.ToString();
            //if (pageNum <= 0)
            //{
            //    return BadRequest();
            //}
            //List<Book> requestedBooks = null;
            //if (!string.IsNullOrEmpty(orderParam))
            //{
            //    requestedBooks = _pageSettingsService.SortBooksBy(orderParam);
            //}
            //if (!string.IsNullOrEmpty(filterParam))
            //{
            //    requestedBooks = _pageSettingsService.FilterBooksBy(filterParam);
            //    pageNum = 1;
            //}
            ////if (requestedBooks != null)
            ////{
            //requestedBooks = _pageSettingsService.NextPage(pageNum, requestedBooks);
            ////}
            List<Book> requestedBooks = _pageSettingsService.Configure(pageNum, 2, orderParam, filterParam, phraseForSearch);
            if (requestedBooks == null)
            {
                return BadRequest();
            }

            return Ok(requestedBooks); // Ok(_pageSettingsService.NextPage(pageNum));
        }
        [HttpGet("/books/{id}")]
        public ActionResult<List<Book>> GetBookBy(int id)
        {
            return Ok();
        }
    }
}
