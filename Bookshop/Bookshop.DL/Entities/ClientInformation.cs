using System;
using System.Collections.Generic;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class ClientInformation
    {
        public ClientInformation()
        {
            GuestClients = new HashSet<GuestClient>();
            Orders = new HashSet<Order>();
            SignedUpClients = new HashSet<SignedUpClient>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        public virtual ICollection<GuestClient> GuestClients { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SignedUpClient> SignedUpClients { get; set; }
    }
}
