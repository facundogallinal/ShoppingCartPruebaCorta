//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Ucu.Poo.eCommerce;

namespace ConsoleApplication
{
    public static class Program
    {
        public static void Main()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            ICoupon discountCoupon = new DiscountCoupon(50);
            ICoupon categoryCoupon = new CategoryCoupon("Bazar", 25);
            ICoupon coupon2x1 = new Coupon2x1();
            Product table = new Product("table", 40, "Bazar");
            Product cup = new Product("cup", 20, "Bazar");
            shoppingCart.AddToCart(table);
            shoppingCart.AddToCart(cup);
            shoppingCart.AddToCart(cup);
            shoppingCart.AddCoupon(discountCoupon);
            Console.WriteLine(shoppingCart.GetTotal());
        }
    }
}