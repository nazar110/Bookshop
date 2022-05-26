using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.BL.Models
{
    public class SenderEmailDetails
    {
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
