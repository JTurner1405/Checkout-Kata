using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheckoutKata.Model.Tests
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod()]
        public void BasketTest()
        {
            var basket = new Basket();

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(0, basket.GetBasketItems().Count());
        }

        [TestMethod()]
        public void AddItemTest()
        {
            var basket = new Basket();

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(0, basket.GetBasketItems().Count());

            var item = new Item("a", 5.13);

            basket.AddItem(item);

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(1, basket.GetBasketItems().Count());
        }

        [TestMethod()]
        public void AddItemMultipleItemsTest()
        {
            var basket = new Basket();

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(0, basket.GetBasketItems().Count());

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 5.13);
            var item2 = new Item("c", 5.13);
            var item3 = new Item("d", 5.13);
            var item4 = new Item("e", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);
            basket.AddItem(item4);

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(5, basket.GetBasketItems().Count());
        }

        [TestMethod()]
        public void AddItemMultipleTimesTest()
        {
            var basket = new Basket();

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(0, basket.GetBasketItems().Count());

            var item = new Item("a", 5.13);
            var item1 = new Item("b",3, 5.13);
            var item2 = new Item("a",2, 5.13);
            var item3 = new Item("c", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);

            Assert.IsNotNull(basket.GetBasketItems());
            Assert.AreEqual(3, basket.GetBasketItems().Count());
        }

        [TestMethod()]
        public void GetBasketTotalTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 3, 5);
            var item2 = new Item("d", 2, 9);
            var item3 = new Item("c", 12);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);

            Assert.AreEqual(50.13, basket.GetBasketTotal());
        }

        [TestMethod()]
        public void GetBasketTotalWithPromotionalDiscountTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 3, 5, 2,0.75,1);
            var item2 = new Item("d", 2, 9);
            var item3 = new Item("c", 12);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);

            Assert.AreEqual(47.63, basket.GetBasketTotal());
        }

        [TestMethod()]
        public void GetBasketTotalWithPromotionalPriceDiscountTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 3, 5, 3, 1, 10);
            var item2 = new Item("d", 2, 9);
            var item3 = new Item("c", 12);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);

            Assert.AreEqual(45.13, basket.GetBasketTotal());
        }

        [TestMethod()]
        public void GetTotalNoOfItemsInBasketTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 3, 5.13);
            var item2 = new Item("a", 2, 5.13);
            var item3 = new Item("c", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);

            Assert.AreEqual(7, basket.GetTotalNoOfItemsInBasket());
        }

        [TestMethod()]
        public void RemoveItemTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 5.13);
            var item2 = new Item("c", 5.13);
            var item3 = new Item("d", 5.13);
            var item4 = new Item("e", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);
            basket.AddItem(item4);

            Assert.AreEqual(5, basket.GetBasketItems().Count());

            basket.RemoveItem(item3);
            Assert.AreEqual(4, basket.GetBasketItems().Count());
            Assert.AreEqual(4, basket.GetTotalNoOfItemsInBasket());
        }

        [TestMethod()]
        public void RemoveItemByIdTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 5.13);
            var item2 = new Item("c", 5.13);
            var item3 = new Item("d", 5.13);
            var item4 = new Item("e", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);
            basket.AddItem(item4);

            Assert.AreEqual(5, basket.GetBasketItems().Count());

            basket.RemoveItem("a", 1);

            Assert.AreEqual(4, basket.GetBasketItems().Count());
            Assert.AreEqual(4, basket.GetTotalNoOfItemsInBasket());
        }

        [TestMethod()]
        public void RemoveItemPartiallyTest()
        {
            var basket = new Basket();

            var item = new Item("a", 5.13);
            var item1 = new Item("b", 5.13);
            var item2 = new Item("c", 5.13);
            var item3 = new Item("d", 5, 5.13);
            var item4 = new Item("e", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);
            basket.AddItem(item4);

            Assert.AreEqual(5, basket.GetBasketItems().Count());


            var item5 = new Item("d", 2, 5.13);

            basket.RemoveItem(item5);
            Assert.AreEqual(5, basket.GetBasketItems().Count());
            Assert.AreEqual(7, basket.GetTotalNoOfItemsInBasket());
        }

        [TestMethod()]
        public void RemoveItemPartialByIdTest()
        {
            var basket = new Basket();

            var item = new Item("a", 10,5.13);
            var item1 = new Item("b", 5.13);
            var item2 = new Item("c", 5.13);
            var item3 = new Item("d", 5.13);
            var item4 = new Item("e", 5.13);

            basket.AddItem(item);
            basket.AddItem(item1);
            basket.AddItem(item2);
            basket.AddItem(item3);
            basket.AddItem(item4);

            Assert.AreEqual(14, basket.GetTotalNoOfItemsInBasket());

            basket.RemoveItem("a", 2);

            Assert.AreEqual(5, basket.GetBasketItems().Count());
            Assert.AreEqual(12, basket.GetTotalNoOfItemsInBasket());
        }
    }
}