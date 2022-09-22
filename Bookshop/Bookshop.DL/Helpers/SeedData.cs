﻿using Bookshop.DL.Entities;
using Bookshop.DL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Helpers
{
    public class SeedData
    {
        public static void SeedAuthorsAndTheirBooks(BookshopContext context)
        {
            List<Book> books = new List<Book>() {
                    new Book()
                    {
                        Title = "Mere Christianity",
                        PublicationYear = 2019,
                        Price = 200,
                    },
                    new Book()
                    {
                        Title = "Kobzar",
                        PublicationYear = 2015,
                        Price = 300,
                    },
                    new Book()
                    {
                        Title = "Tyhrolovy",
                        PublicationYear = 2014,
                        Price = 240,
                    }
                };

            List<Author> authors = new List<Author>()
                {
                    new Author()
                    {
                        Name = "Clive",
                        Surname = "Lewis",
                        About = "Lorem ipsum"
                    },
                    new Author()
                    {
                        Name = "Taras",
                        Surname = "Shevchenko",
                        About = "Lorem ipsum"
                    },
                    new Author()
                    {
                        Name = "Ivan",
                        Surname = "Bahrianyi",
                        About = "Lorem ipsum"
                    }
                };

            List<AuthorsBooks> authorsBooks = new List<AuthorsBooks>()
                {
                    new AuthorsBooks()
                    {
                        AuthorID = authors[0].Id,
                        Author = authors[0],
                        BookID = books[0].ID,
                        Book = books[0],
                    },
                    new AuthorsBooks()
                    {
                        AuthorID = authors[1].Id,
                        Author = authors[1],
                        BookID = books[1].ID,
                        Book = books[1],
                    },
                    new AuthorsBooks()
                    {
                        AuthorID = authors[2].Id,
                        Author = authors[2],
                        BookID = books[2].ID,
                        Book = books[2],
                    }
                };

            authors[0].AuthorsBooks = new List<AuthorsBooks>() { authorsBooks[0] };
            authors[1].AuthorsBooks = new List<AuthorsBooks>() { authorsBooks[1] };
            authors[2].AuthorsBooks = new List<AuthorsBooks>() { authorsBooks[2] };

            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "Theology"
                },
                new Genre()
                {
                    Name = "Poetry"
                },
                new Genre()
                {
                    Name = "Novel"
                }
            };

            var booksGenres = new List<BooksGenres>()
            {
                new BooksGenres()
                {
                    BookID = books[0].ID,
                    Book = books[0],
                    GenreID = genres[0].ID,
                    Genre = genres[0]
                },
                new BooksGenres()
                {
                    BookID = books[1].ID,
                    Book = books[1],
                    GenreID = genres[1].ID,
                    Genre = genres[1]
                },
                new BooksGenres()
                {
                    BookID = books[2].ID,
                    Book = books[2],
                    GenreID = genres[2].ID,
                    Genre = genres[2]
                }
            };
            
            context.Books.AddRange(books);
            context.Genres.AddRange(genres);
            context.Authors.AddRange(authors);
            context.AuthorsBooks.AddRange(authorsBooks);
            context.BooksGenres.AddRange(booksGenres);

            context.SaveChanges();
        }
    }
}
