using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookshop.DL.Entities
{
    public partial class Genre
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public List<BooksGenres> BooksGenres { get; set; }
    }
}
