using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Model
{
    /// <summary>
    /// Item class
    /// </summary>
    public class Item : IItem
    {
        //variables
        private string Id;
        private int Quantity;
        private double Price;
        private int PromotionalQuantity;
        private double PromotionalDiscount;
        private double PromotionalPrice;

        /// <summary>
        /// Constructor to create basic item with id & price
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <param name="price">Price of Item</param>
        public Item(string id, double price) : this(id, 1, price)
        {
            
        }

        /// <summary>
        /// Constructor to set all values of item along without promotional offers
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <param name="quantity">Initial Quantity of item</param>
        /// <param name="price">Price of item</param>
        public Item(string id, int quantity, double price) : this(id, quantity, price, 1, 1,1)
        {

        }

        /// <summary>
        /// Constructor to set all values of item along with promotional offers
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <param name="quantity">Initial Quantity of item</param>
        /// <param name="price">Price of item</param>
        /// <param name="promotionalQuantity">Promotional Quantity required</param>
        /// <param name="promotionalDiscount">Promotional Discount to apply</param>
        /// <param name="promotionalPrice">Promotional Price to set</param>
        public Item(string id, int quantity, double price, int promotionalQuantity, double promotionalDiscount, double promotionalPrice)
        {
            this.Id = id;
            this.Price = price;
            this.Quantity = quantity;
            this.PromotionalDiscount = promotionalDiscount;
            this.PromotionalQuantity = promotionalQuantity;
            this.PromotionalPrice = promotionalPrice;
        }

        /// <summary>
        /// Get Item Id
        /// </summary>
        /// <returns>Item Id</returns>
        public string GetId()
        {
            return Id;
        }

        /// <summary>
        /// Get number of items
        /// </summary>
        /// <returns>Quantity of Item</returns>
        public int GetQuantity()
        {
            return Quantity;
        }

        /// <summary>
        /// Get Price of Item
        /// </summary>
        /// <returns>Price of Item</returns>
        public double GetPrice()
        {
            return Price;
        }

        /// <summary>
        /// Get promotional Quantity required
        /// </summary>
        /// <returns>Quantity for promotion to activate</returns>
        public int GetPromotionalQuanity()
        {
            return PromotionalQuantity;
        }

        /// <summary>
        /// Get Promotional discount multiplier
        /// </summary>
        /// <returns>Promotional discount multiplier value</returns>
        public double GetPromotionalDiscountMultiplier()
        {
            return PromotionalDiscount;
        }

        /// <summary>
        /// Get Promotional discount price
        /// </summary>
        /// <returns>Promotional discount price value</returns>
        public double GetPromotionalPrice()
        {
            return PromotionalPrice;
        }

        /// <summary>
        /// Increase quantity of item
        /// </summary>
        /// <param name="toAdd">Quanity to increase by</param>
        public void AddItem(int toAdd)
        {
            this.Quantity += toAdd;
        }

        /// <summary>
        /// Get total price of all of this item
        /// </summary>
        /// <returns>price of all items</returns>
        public double GetTotalPrice()
        {
            if (this.Quantity == 0)
            {
                return 0;
            }

            double sum;

            if (PromotionalDiscount < 1 || PromotionalPrice > 1)
            {
                return CalculatePromotionalPrice();
            }
            else
            {
                sum = Quantity * Price;
            }

            return sum;
        }

        /// <summary>
        /// Calculate promotional price
        /// </summary>
        /// <returns>Price with promotion applied</returns>
        private double CalculatePromotionalPrice()
        {
            double sum;
            int promotionalCount = this.Quantity / this.PromotionalQuantity;
            int promotionalRemainder = this.Quantity % this.PromotionalQuantity;

            if (PromotionalPrice > 1)
            {
                sum = (promotionalCount * PromotionalPrice);
            }
            else
            {
                sum = ((promotionalCount * this.PromotionalQuantity) * (this.Price * PromotionalDiscount));
            }

            sum += (promotionalRemainder * this.Price);

            return sum;
        }

        /// <summary>
        /// Decrease quanity of item
        /// </summary>
        /// <param name="toRemove">Quantity to decrease by</param>
        public void RemoveItem(int toRemove)
        {
            this.Quantity -= toRemove;

            if (this.Quantity <= 0)
            {
                this.Quantity = 0;
            }
                
        }

        /// <summary>
        /// Set promotional discount
        /// </summary>
        /// <param name="quantity">no of items required</param>
        /// <param name="multiplier">multiplier to be added for promotion</param>
        public void SetPromotionDiscount(int quantity, double multiplier)
        {
            this.PromotionalQuantity = quantity;
            this.PromotionalDiscount = multiplier;
        }

        /// <summary>
        /// Set promotional discount
        /// </summary>
        /// <param name="quantity">no of items required</param>
        /// <param name="price">price for promotion</param>
        public void SetPromotionPrice(int quantity, double price)
        {
            this.PromotionalQuantity = quantity;
            this.PromotionalDiscount = 1;
            this.PromotionalPrice = price;
        }
    }
}
