using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CheckOutApp;

namespace CheckOutAppTest
{
    [TestFixture]
    public class CheckoutTest
    {
        /*
        A 1 0.50 
        A 2 1.00 
        A 3 1.30
 
        B 1 0.30 
        B 2 0.45 
        B 3 75
 
        C 1 0.60 
        C 2 1.20 
        C 3 1.80
        */
        [TestCase(1, 0.50, 3, 0.20, 0, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 0.50)]
        [TestCase(2, 0.50, 3, 0.20, 0, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 1.00)]
        [TestCase(3, 0.50, 3, 0.20, 0, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 1.30)]
        [TestCase(4, 0.50, 3, 0.20, 0, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 1.80)]
        [TestCase(6, 0.50, 3, 0.20, 0, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 2.60)]
        [TestCase(6, 0.50, 3, 0.20, 1, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 2.90)]
        [TestCase(6, 0.50, 3, 0.20, 2, 0.30, 2, 0.15, 0, 0.60, 1, 0.0, 3.05)]
        [TestCase(6, 0.50, 3, 0.20, 2, 0.30, 2, 0.15, 1, 0.60, 1, 0.0, 3.65)]

        public void TestCheckOut(
            int quantityOfA, decimal unitPriceOfA, int offerQuantityOfA, decimal offerPriceOfA,
            int quantityOfB, decimal unitPriceOfB, int offerQuantityOfB, decimal offerPriceOfB,
            int quantityOfC, decimal unitPriceOfC, int offerQuantityOfC, decimal offerPriceOfC,
            decimal expectedTotal
        )
        {

            var checkOut = new Checkout();
            var itemList = new Dictionary<Item, int>();
          
            itemList.Add(new Item { OfferQuantity = offerQuantityOfA, OfferPrice = offerPriceOfA, Sku = "A99", UnitPrice = unitPriceOfA }, quantityOfA);
            itemList.Add(new Item { OfferQuantity = offerQuantityOfB, OfferPrice = offerPriceOfB, Sku = "B15", UnitPrice = unitPriceOfB }, quantityOfB);
            itemList.Add(new Item { OfferQuantity = offerQuantityOfC, OfferPrice = offerPriceOfC, Sku = "C45", UnitPrice = unitPriceOfC }, quantityOfC);
      


            decimal totalPrice = checkOut.Total(itemList);
            Assert.That(totalPrice, Is.EqualTo(expectedTotal));
        }
    }
}
