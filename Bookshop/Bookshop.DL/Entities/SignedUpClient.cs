using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class SignedUpClient
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public int? ClientInformationID { get; set; }

        public virtual ClientInformation ClientInformation { get; set; }
    }
}
