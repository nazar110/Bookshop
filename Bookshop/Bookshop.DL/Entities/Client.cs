using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Entities
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        [MinLength(6, ErrorMessage = "Minimum password length can be 6")]
        public string Password { get; set; }
        public List<Order> Orders { get; set; }
    }
}
