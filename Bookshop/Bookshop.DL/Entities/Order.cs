using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bookshop.DL.Entities
{
    public partial class Order
    {
        [Key]
        public int ID { get; set; }
        public DateTime? DateCreated { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
