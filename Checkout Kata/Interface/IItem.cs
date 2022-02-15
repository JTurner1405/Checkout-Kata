namespace CheckoutKata.Interface
{
    /// <summary>
    /// Interface for Item operations
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Get total price of all of this item
        /// </summary>
        /// <returns>price of all items</returns>
        double GetTotalPrice();

        /// <summary>
        /// Increase quantity of item
        /// </summary>
        /// <param name="toAdd">Quanity to increase by</param>
        void AddItem(int toAdd);

        /// <summary>
        /// Decrease quanity of item
        /// </summary>
        /// <param name="toRemove">Quantity to decrease by</param>
        void RemoveItem(int toRemove);

        /// <summary>
        /// Set promotional discount
        /// </summary>
        /// <param name="quantity">no of items required</param>
        /// <param name="multiplier">multiplier to be added for promotion</param>
        void SetPromotionDiscount(int quantity, double multiplier);

        /// <summary>
        /// Set promotional discount
        /// </summary>
        /// <param name="quantity">no of items required</param>
        /// <param name="price">price for promotion</param>
        void SetPromotionPrice(int quantity, double price);

        /// <summary>
        /// Get Item Id
        /// </summary>
        /// <returns>Item Id</returns>
        string GetId();

        /// <summary>
        /// Get number of items
        /// </summary>
        /// <returns>Quantity of Item</returns>
        int GetQuantity();

        /// <summary>
        /// Get Price of Item
        /// </summary>
        /// <returns>Price of Item</returns>
        double GetPrice();

        /// <summary>
        /// Get promotional Quantity required
        /// </summary>
        /// <returns>Quantity for promotion to activate</returns>
        int GetPromotionalQuanity();

        /// <summary>
        /// Get Promotional discount multiplier
        /// </summary>
        /// <returns>Promotional discount multiplier value</returns>
        double GetPromotionalDiscountMultiplier();

        /// <summary>
        /// Get Promotional discount price
        /// </summary>
        /// <returns>Promotional discount price value</returns>
        double GetPromotionalPrice();

    }
}
