using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class GuestClient
    {
        public int ID { get; set; }
        public int? ClientInformationID { get; set; }

        public virtual ClientInformation ClientInformation { get; set; }
    }
}
