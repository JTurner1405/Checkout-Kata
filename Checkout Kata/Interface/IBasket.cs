using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interface
{
    /// <summary>
    /// Interface for basket operations
    /// </summary>
    public interface IBasket
    {
        /// <summary>
        /// Add item to basket list
        /// </summary>
        /// <param name="item">Item to be added</param>
        void AddItem(IItem item);

        /// <summary>
        /// Add item to basket list by id
        /// </summary>
        /// <param name="itemId">id of item to add</param>
        /// <param name="count">quanity of item to add to basket</param>
        void AddItem(string itemId, int count);

        /// <summary>
        /// Remove item from basket list
        /// </summary>
        /// <param name="item">Item to be removed from basket</param>
        void RemoveItem(IItem item);

        /// <summary>
        /// Remove Item from basket list based on id
        /// </summary>
        /// <param name="itemId">id of item to remove</param>
        /// <param name="count">quantity to remove</param>
        void RemoveItem(string itemId, int count);

        /// <summary>
        /// Get total price of all items in the basket
        /// </summary>
        /// <returns>Total price for basket</returns>
        double GetBasketTotal();

        /// <summary>
        /// Get Total number of items in the basket
        /// </summary>
        /// <returns>Number of items in basket</returns>
        int GetTotalNoOfItemsInBasket();
    }
}
