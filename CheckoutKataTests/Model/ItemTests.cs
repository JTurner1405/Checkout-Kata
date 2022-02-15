using CheckoutKata.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKataTests.Model.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        [DataRow(1,2,2)]
        [DataRow(5,3,15)]
        [DataRow(2,10.5,21)]
        [DataRow(0, 10.5, 0)]
        public void GetTotalPriceTest(int quantity, double price, double expectedPrice)
        {
            var newItem = new Item("a", quantity, price);

            Assert.AreEqual(expectedPrice, newItem.GetTotalPrice());
        }

        [TestMethod]
        [DataRow(1, 15, 3, 1, 40, 15)]
        [DataRow(3, 15, 3, 1, 40, 40)]
        [DataRow(6, 15, 3, 1, 40, 80)]
        [DataRow(4, 15, 3, 1, 40, 55)]
        [DataRow(5, 15, 3, 1, 40, 70)]
        [DataRow(1, 55, 2, 0.75, 1, 55)]  
        [DataRow(2, 55, 2, 0.75, 1, 82.5)]
        [DataRow(4, 55, 2, 0.75, 1, 165)]
        [DataRow(5, 55, 2, 0.75, 1, 220)]
        [DataRow(5, 55, 1, 0.75, 1, 206.25)]
        public void GetTotalPriceWithPromotionTest(int quantity, double price,int promotionQuantity, double promotionMultiplier, double promotionPrice, double expectedPrice)
        {
            var newItem = new Item("a", quantity, price, promotionQuantity, promotionMultiplier, promotionPrice);

            Assert.AreEqual(expectedPrice, newItem.GetTotalPrice());
        }

        [TestMethod]
        [DataRow(1,1,2)]
        [DataRow(5, 1, 6)]
        [DataRow(5, 1, 6)]
        [DataRow(5, 11, 16)]
        public void AddItemTest(int intialQuantity, int quantityToAdd, int expectedQuantity)
        {
            var newItem = new Item("a", intialQuantity, 5.5);

            Assert.AreEqual(intialQuantity, newItem.GetQuantity());

            newItem.AddItem(quantityToAdd);

            Assert.AreEqual(expectedQuantity, newItem.GetQuantity());
        }

        [TestMethod]
        public void ItemCreationTest()
        {
            var newItem = new Item("b", 5.6);

            Assert.AreEqual("b", newItem.GetId());
            Assert.AreEqual(5.6, newItem.GetPrice());
            Assert.AreEqual(1, newItem.GetQuantity());
            Assert.AreEqual(1, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(1, newItem.GetPromotionalPrice());
            Assert.AreEqual(1, newItem.GetPromotionalQuanity());
        }

        [TestMethod]
        public void ItemCreationWithQuantityTest()
        {
            var newItem = new Item("b", 5, 5.9);

            Assert.AreEqual("b", newItem.GetId());
            Assert.AreEqual(5.9, newItem.GetPrice());
            Assert.AreEqual(5, newItem.GetQuantity());
            Assert.AreEqual(1, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(1, newItem.GetPromotionalPrice());
            Assert.AreEqual(1, newItem.GetPromotionalQuanity());
        }

        [TestMethod]
        public void ItemCreationWithPromotionalDiscountTest()
        {
            var newItem = new Item("b", 5, 5.9, 2, 0.75,1);

            Assert.AreEqual("b", newItem.GetId());
            Assert.AreEqual(5.9, newItem.GetPrice());
            Assert.AreEqual(5, newItem.GetQuantity());
            Assert.AreEqual(0.75, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(1, newItem.GetPromotionalPrice());
            Assert.AreEqual(2, newItem.GetPromotionalQuanity());
        }

        [TestMethod]
        public void ItemCreationWithPromotionalPriceTest()
        {
            var newItem = new Item("b", 5, 5.9, 2, 1, 50);

            Assert.AreEqual("b", newItem.GetId());
            Assert.AreEqual(5.9, newItem.GetPrice());
            Assert.AreEqual(5, newItem.GetQuantity());
            Assert.AreEqual(1, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(50, newItem.GetPromotionalPrice());
            Assert.AreEqual(2, newItem.GetPromotionalQuanity());
        }

        [TestMethod]
        [DataRow(5,1,4)]
        [DataRow(9, 1, 8)]
        [DataRow(1, 5, 0)]
        [DataRow(1, 0, 1)]
        public void RemoveItemTest(int intialQuantity, int quantityToRemove, int expectedQuantity)
        {
            var newItem = new Item("b", intialQuantity, 5.6);

            Assert.AreEqual(intialQuantity, newItem.GetQuantity());

            newItem.RemoveItem(quantityToRemove);

            Assert.AreEqual(expectedQuantity, newItem.GetQuantity());
        }

        [TestMethod]
        [DataRow(1,1)]
        [DataRow(5,0.75)]
        [DataRow(3, 0.75)]
        [DataRow(2, 0.5)]
        public void SetPromotionDiscountTest(int promotionalQuantity, double promotionalMultiplier)
        {
            var newItem = new Item("b", 5, 5.9, 2, 0.9, 1);

            Assert.AreEqual("b", newItem.GetId());
            Assert.AreEqual(5.9, newItem.GetPrice());
            Assert.AreEqual(5, newItem.GetQuantity());
            Assert.AreEqual(0.9, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(1, newItem.GetPromotionalPrice());
            Assert.AreEqual(2, newItem.GetPromotionalQuanity());

            newItem.SetPromotionDiscount(promotionalQuantity, promotionalMultiplier);

            Assert.AreEqual(promotionalMultiplier, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(1, newItem.GetPromotionalPrice());
            Assert.AreEqual(promotionalQuantity, newItem.GetPromotionalQuanity());
        }
    

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 40)]
        [DataRow(6, 90)]
        [DataRow(12, 20)]
        public void SetPromotionPriceTest(int promotionalQuantity, double promotionalPrice)
        {
            var newItem = new Item("b", 5, 5.9, 2, 0.5, 50);

            Assert.AreEqual("b", newItem.GetId());
            Assert.AreEqual(5.9, newItem.GetPrice());
            Assert.AreEqual(5, newItem.GetQuantity());
            Assert.AreEqual(0.5, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(50, newItem.GetPromotionalPrice());
            Assert.AreEqual(2, newItem.GetPromotionalQuanity());

            newItem.SetPromotionPrice(promotionalQuantity, promotionalPrice);

            Assert.AreEqual(1, newItem.GetPromotionalDiscountMultiplier());
            Assert.AreEqual(promotionalPrice, newItem.GetPromotionalPrice());
            Assert.AreEqual(promotionalQuantity, newItem.GetPromotionalQuanity());
        }
    }
}