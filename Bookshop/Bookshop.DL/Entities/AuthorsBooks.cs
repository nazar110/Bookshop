using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class AuthorsBooks
    {
        public int AuthorID { get; set; }
        public int BookID { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
