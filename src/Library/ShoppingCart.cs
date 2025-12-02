using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Ucu.Poo.eCommerce
{
    public class ShoppingCart
    {
        public class CartItem
        {
            public Product Product { get; }
            public int Quantity { get; internal set; }

            public CartItem(Product product)
            {
                this.Product = product;
                this.Quantity = 1;
            }

            public double GetItemTotal()
            {
                return this.Product.Price * this.Quantity;
            }
        }

        private List<CartItem> items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        private CartItem GetItemWithProduct(Product product)
        {
            foreach (CartItem item in this.items)
            {
                if (item.Product == product)
                {
                    return item;
                }
            }

            return null;
        }

        public void AddToCart(Product product)
        {
            CartItem item = this.GetItemWithProduct(product);
            if (item != null)
            {
                item.Quantity += 1;
            }
            else
            {
                this.items.Add(new CartItem(product));
            }
        }

        public void RemoveFromCart(Product product)
        {
            CartItem item = this.GetItemWithProduct(product);
            if (item != null)
            {
                if (item.Quantity == 1)
                {
                    this.items.Remove(item);
                }
                else
                {
                    item.Quantity -= 1;
                }
            }
        }

        public double GetTotal()
        {
            double result = 0.0;
            foreach (CartItem item in this.items)
            {
                result += item.GetItemTotal();
            }

            return result;
        }
    }
}
