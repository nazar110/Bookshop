using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class BooksGenres
    {
        public int BookID { get; set; }
        public int GenreID { get; set; }

        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
