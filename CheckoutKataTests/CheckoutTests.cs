using CheckoutKata.Interface;
using CheckoutKata.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataTests
{
    [TestClass]
    public class CheckoutTests
    {
        private IBasket basket;

        private IItem itemA; 
        private IItem itemB; 
        private IItem itemC; 
        private IItem itemD; 

        [TestInitialize]
        public void InitilizeTests()
        {
            basket = new Basket();
            itemA = new Item("A", 10);
            itemB = new Item("B", 1, 15, 3, 1, 40);
            itemC = new Item("C", 40);
            itemD = new Item("D", 1, 55, 2, 0.75, 1);
        }

        [TestMethod]
        public void Test()
        {
            basket.AddItem(itemA);
            basket.AddItem(itemB);
            basket.AddItem(itemC);
            basket.AddItem(itemD);

            Assert.AreEqual(120, basket.GetBasketTotal());
        }

        [TestMethod]
        public void TestWithPromotion()
        {
            basket.AddItem(itemA);
            itemB.AddItem(5);
            basket.AddItem(itemB);
            basket.AddItem(itemC);
            itemD.AddItem(1);
            basket.AddItem(itemD);

            Assert.AreEqual(212.5, basket.GetBasketTotal());
        }
    }
}
