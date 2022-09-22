using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshop.DL.Entities
{
    public partial class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        [MaxLength(255, ErrorMessage = "The max langth can be 255")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(10, 10)")]
        public decimal? Price { get; set; }
        public int? NumOfPages { get; set; }
        public int? PublicationYear { get; set; }
        public string PublisherName { get; set; }
        [Column(TypeName = "decimal(10, 10)")]
        public decimal? Weight { get; set; }

        public List<AuthorsBooks> AuthorsBooks { get; set; }
        public List<BooksGenres> BooksGenres { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
