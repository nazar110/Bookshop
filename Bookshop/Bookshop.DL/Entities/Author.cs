using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookshop.DL.Entities
{
    public partial class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }

        public List<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
