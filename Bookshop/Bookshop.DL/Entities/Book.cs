using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
            BooksGenres = new HashSet<BooksGenre>();
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

        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
        public virtual ICollection<BooksGenre> BooksGenres { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
