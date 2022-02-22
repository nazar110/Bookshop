using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ID { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ClientInformationID { get; set; }

        public virtual ClientInformation ClientInformation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
