using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class BooksGenres
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BookID")]
        public int BookID { get; set; }
        public Book Book { get; set; }
        [ForeignKey("GenreID")]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
