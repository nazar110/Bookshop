using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class OrderItem
    {
        public int ID { get; set; }
        public int? Quantity { get; set; }
        public int? OrderID { get; set; }
        public int? BookID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
