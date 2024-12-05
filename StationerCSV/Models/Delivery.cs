using System;
using System.Collections.Generic;
using System.Linq;
using Stationery.Models;

namespace Stationery.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int GoodsId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
    }

}