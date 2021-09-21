using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp
{
    public class Item
    {
        public string Sku { get; set; }
        public decimal UnitPrice { get; set; }
        public int OfferQuantity { get; set; }
        public decimal OfferPrice { get; set; }
    }
}
