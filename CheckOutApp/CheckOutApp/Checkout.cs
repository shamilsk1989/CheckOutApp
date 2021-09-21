using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp
{
    public class Checkout
    {
        public decimal Total(Dictionary<Item, int> itemList)
        {

            decimal totalPrice = 0;
            foreach (var item in itemList)
            {
                totalPrice += item.Value * item.Key.UnitPrice;
                int extraQuantity = item.Value / item.Key.OfferQuantity;
                totalPrice -= extraQuantity * item.Key.OfferPrice;

            }
            return totalPrice;
        }
    }
}
