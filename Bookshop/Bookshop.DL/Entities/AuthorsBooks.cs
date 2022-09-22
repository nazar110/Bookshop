using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshop.DL.Entities
{
    public partial class AuthorsBooks
    {
        [Key]
        public int Key { get; set; }
        [ForeignKey("AuthorID")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        [ForeignKey("BookID")]
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
