using Bookshop.BL.DTOs;
using Bookshop.BL.Models;
using Bookshop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.BL.Services
{
    public class BookService
    {
        private readonly IUnitOfWork _uow;
        public BookService(IUnitOfWork uow)
        {
            _uow = uow;
            //_uow.Orders.Create(new DL.Entities.Order());
        }
        public List<BookDto> GetAll()
        {
            var books = new List<BookDto>() {
                new BookDto()
                {
                    Title = "Mere Christianity",
                    PublicationYear = 2019,
                    AuthorName = "Clive",
                    AuthorSurname = "Lewis",
                    Price = 200,
                },
                new BookDto()
                {
                    Title = "Kobzar",
                    PublicationYear = 2015,
                    AuthorName = "Taras",
                    AuthorSurname = "Shevchenko",
                    Price = 300,
                },
                new BookDto()
                {
                    Title = "Tyhrolovy",
                    PublicationYear = 2014,
                    AuthorName = "Ivan",
                    AuthorSurname = "Bahrianyi",
                    Price = 240,
                }
            };
            return books;
        }
        public BookDto GetBy(int id)
        {
            var books = new List<BookDto>() {
                new BookDto()
                {
                    Title = "Mere Christianity",
                    PublicationYear = 2019,
                    AuthorName = "Clive",
                    AuthorSurname = "Lewis",
                    Price = 200,
                },
                new BookDto()
                {
                    Title = "Kobzar",
                    PublicationYear = 2015,
                    AuthorName = "Taras",
                    AuthorSurname = "Shevchenko",
                    Price = 300,
                },
                new BookDto()
                {
                    Title = "Tyhrolovy",
                    PublicationYear = 2014,
                    AuthorName = "Ivan",
                    AuthorSurname = "Bahrianyi",
                    Price = 240,
                }
            };
            BookDto book = null;
            try
            {
                book = books[id];
            }
            catch (Exception)
            {
                book = books[0];
            }
            return book;
        }
    }
}
