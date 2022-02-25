using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
            BooksGenres = new HashSet<BooksGenres>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? NumOfPages { get; set; }
        public int? PublicationYear { get; set; }
        public string PublisherName { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
