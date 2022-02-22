using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }

        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
    }
}
