using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stationery.Models;

namespace Stationery.Models
{
    public class Goods
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsColor { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}