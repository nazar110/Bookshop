using Bookshop.BL.Constants;
using Bookshop.BL.Helpers;
using Bookshop.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.BL.Services
{
    public class PageSettingsService
    {
        // public PageViewModel PageViewModel { get; set; }
        public IEnumerable<Book> BooksDetails { get; set; } = new List<Book>() {
        new Book()
        {
            Title = "Mere Christianity",
            PublicationYear = 2019,
            AuthorName = "Clive",
            AuthorSurname = "Lewis",
            Price = 200,
        },
        new Book()
        {
            Title = "Kobzar",
            PublicationYear = 2015,
            AuthorName = "Taras",
            AuthorSurname = "Shevchenko",
            Price = 300,
        },
        new Book()
        {
            Title = "Tyhrolovy",
            PublicationYear = 2014,
            AuthorName = "Ivan",
            AuthorSurname = "Bahrianyi",
            Price = 240,
        }
        };
        // Pass to methods second parameter List<Book> requestedBooks
        public List<Book> NextPage(int pageNum, int numberOfItemsPerPage, List<Book> requestedBooks)
        {
            // int pageSize = 2;
            // var count = requestedBooks.Count();
            var items = requestedBooks.Skip((pageNum - 1) * numberOfItemsPerPage).Take(numberOfItemsPerPage).ToList();
            //int totalPages = (int)Math.Ceiling(count / (double)numberOfItemsPerPage);
            //bool previousPageExists = pageNum > 1;
            //bool nextPageExists = pageNum < totalPages;
            return items;
        }
        public List<Book> SortBooksBy(string parameter)
        {
            List<Book> items;
            if (parameter == OrderParameter.AuthorName)
            {
                items = BooksDetails.OrderBy(b => b.AuthorName).ToList();
            }
            else if (parameter == OrderParameter.Price)
            {
                items = BooksDetails.OrderBy(b => b.Price).ToList();
            }
            else if (parameter == OrderParameter.Title)
            {
                items = BooksDetails.OrderBy(b => b.Title).ToList();
            }
            else
            {
                items = BooksDetails.OrderBy(b => b.Title).ToList();
            }
            return items;
        }
        public List<Book> FilterBooksBy(string parameter)
        {
            List<Book> items = BooksDetails.Where(b => $"{b.AuthorName} {b.AuthorSurname}" == parameter 
            || b.Title == parameter).ToList();
            return items;
        }
        public List<Book> SearchBooksBy(string phraseForSearch)
        {
            List<Book> items = BooksDetails.Where(b => b.AuthorName.Contains(phraseForSearch) ||
            $"{b.AuthorName} {b.AuthorSurname}".Contains(phraseForSearch) ||
            b.AuthorSurname.Contains(phraseForSearch) || b.Title.Contains(phraseForSearch)).ToList();
            return items;
        }
        public List<Book> Configure(int pageNum, int numberOfItemsPerPage, string orderParam, string filterParam, string phraseForSearch)
        {
            //Int32.TryParse(pageValue.ToString(), out int pageNum);
            //string orderParam = orderValue.ToString();
            // string filterParam = filterValue.ToString();

            //if (pageNum <= 0)
            //{
            //    pageNum = 1;
            //}

            List<Book> requestedBooks = BooksDetails.ToList();
            if (!string.IsNullOrEmpty(orderParam))
            {
                requestedBooks = SortBooksBy(orderParam);
            }
            if (!string.IsNullOrEmpty(filterParam))
            {
                requestedBooks = FilterBooksBy(filterParam);
                pageNum = 1;
            }
            if (!string.IsNullOrEmpty(phraseForSearch))
            {
                requestedBooks = SearchBooksBy(phraseForSearch);
                pageNum = 1;
            }

            int totalPages = (int)Math.Ceiling(requestedBooks.Count() / (double)numberOfItemsPerPage);
            bool previousPageExists = pageNum > 1;
            bool nextPageExists = pageNum < totalPages;
            if (previousPageExists == false)
            {
                pageNum = 1;
            }
            if (nextPageExists == false)
            {
                pageNum = totalPages;
            }

            //if (requestedBooks != null)
            //{
            requestedBooks = NextPage(pageNum, numberOfItemsPerPage, requestedBooks);
            //}
            
            return requestedBooks;
        }
    }

}
