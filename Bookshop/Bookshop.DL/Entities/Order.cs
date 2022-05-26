using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Order
    {
        public int ID { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<ClientsOrders> ClientsOrders { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
