using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Model
{
    /// <summary>
    /// Create Basket class
    /// </summary>
    public class Basket : IBasket
    {
        private readonly List<IItem> basketList;

        /// <summary>
        /// Creates intial basket without any items added
        /// </summary>
        public Basket()
        {
            basketList = new List<IItem>();
        }

        /// <summary>
        /// Get list of all items in basket
        /// </summary>
        /// <returns>All items in basket</returns>
        public List<IItem> GetBasketItems()
        {
            return basketList;
        }

        /// <summary>
        /// Add item to basket list
        /// </summary>
        /// <param name="item">Item to be added</param>
        public void AddItem(IItem item)
        {
            var existingItem = basketList.FirstOrDefault(x => x.GetId().Equals(item.GetId()));

            if (existingItem != null)
            {
                existingItem.AddItem(item.GetQuantity());
            }
            else
            {
                basketList.Add(item);
            }
        }

        /// <summary>
        /// Get total price of all items in the basket
        /// </summary>
        /// <returns>Total price for basket</returns>
        public double GetBasketTotal()
        {
            double totalPrice = 0;

            foreach(var item in basketList)
            {
                totalPrice += item.GetTotalPrice();
            }

            return Math.Round(totalPrice, 2);
        }

        /// <summary>
        /// Get Total number of items in the basket
        /// </summary>
        /// <returns>Number of items in basket</returns>
        public int GetTotalNoOfItemsInBasket()
        {
            var totalCount = 0;

            foreach(var item in basketList)
            {
                totalCount += item.GetQuantity();
            }

            return totalCount;
        }

        /// <summary>
        /// Remove item from basket list
        /// </summary>
        /// <param name="item">Item to be removed from basket</param>
        public void RemoveItem(IItem item)
        {
            var existingItem = basketList.FirstOrDefault(x => x.GetId().Equals(item.GetId()));

            if (existingItem != null)
            {
                existingItem.RemoveItem(item.GetQuantity());

                if(existingItem.GetQuantity() == 0)
                {
                    basketList.Remove(existingItem);
                }
            }
        }

        /// <summary>
        /// Remove Item from basket list based on id
        /// </summary>
        /// <param name="itemId">id of item to remove</param>
        /// <param name="count">quantity to remove</param>
        public void RemoveItem(string itemId, int count)
        {
            var existingItem = basketList.FirstOrDefault(x => x.GetId().Equals(itemId));

            if (existingItem != null)
            {
                existingItem.RemoveItem(count);

                if (existingItem.GetQuantity() == 0)
                {
                    basketList.Remove(existingItem);
                }
            }
        }
    }
}
