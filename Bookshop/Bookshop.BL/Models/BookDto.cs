using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.BL.Models
{
    public class BookDto
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public double Price { get; set; }
    }
}
