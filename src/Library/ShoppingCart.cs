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

        private List<ICoupon> coupons = new List<ICoupon>();

        public IReadOnlyList<ICoupon> Coupons
        {
            get
            {
                return this.coupons.AsReadOnly();
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

        /// <summary>
        /// Si hay un DiscountCoupon agregado lanza una excepcion por no poder acumularlo con otro, lo mismo si intento agregar un DiscountCoupon a una lista con más cupones.
        /// </summary>
        /// <param name="coupon"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddCoupon(ICoupon coupon)
        {
            if (this.coupons.Count == 0 || this.coupons == null)
            {
                this.coupons.Add(coupon);
            }
            else if (coupon is DiscountCoupon)
            {
                throw new ArgumentException(
                    "No puedes agregar un DiscountCoupon si tienes más cupones, si quieres usar este cupón debes quitar los demás");
            }
            else
            {
                if (this.coupons[0] is DiscountCoupon)
                {
                    throw new ArgumentException("No se puede acumular un cupon con el DiscountCoupon que ya tienes agregado");
                }
                else
                {
                    this.coupons.Add(coupon);
                }
            }
        }

        public void ClearCoupons()
        {
            this.coupons = new List<ICoupon>();
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
            if (this.coupons.Count == 0 || this.coupons == null)
            {
                foreach (CartItem item in this.items)
                {
                    result += item.GetItemTotal();
                }
            }
            else
            {
                foreach (CartItem item in this.items)
                {
                    foreach (ICoupon coupon in this.coupons)
                    {
                        result += coupon.Discount(item);
                    }
                }
            }
            return result;
        }
    }
}
