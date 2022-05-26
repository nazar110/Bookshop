using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Entities
{
    public class ClientsOrders
    {
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
