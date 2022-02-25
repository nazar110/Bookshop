using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            BooksGenres = new HashSet<BooksGenres>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
    }
}
