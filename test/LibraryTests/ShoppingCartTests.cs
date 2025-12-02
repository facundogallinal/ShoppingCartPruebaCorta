// ShoppingCartTests.cs
using NUnit.Framework;
using Ucu.Poo.eCommerce;
using System;
using System.Collections.Generic;

namespace Ucu.Poo.eCommerce.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void Items_OnNewCart_StartsEmpty()
        {
            var cart = new ShoppingCart();

            Assert.That(cart.Items, Is.Not.Null);
            Assert.That(cart.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddToCart_WithSingleProduct_AddsItemToCart()
        {
            var cart = new ShoppingCart();
            var mouse = new Product("Mouse", 25.5, "Accessories");

            cart.AddToCart(mouse);

            Assert.That(cart.Items.Count, Is.EqualTo(1));
            Assert.That(cart.Items[0].Product, Is.SameAs(mouse));
            Assert.That(cart.Items[0].Quantity, Is.EqualTo(1));
        }

        [Test]
        public void AddToCart_WithSameProductTwice_IncrementsQuantity()
        {
            var cart = new ShoppingCart();
            var mouse = new Product("Mouse", 25.5, "Accessories");

            cart.AddToCart(mouse);
            cart.AddToCart(mouse);

            Assert.That(cart.Items.Count, Is.EqualTo(1));
            Assert.That(cart.Items[0].Product, Is.SameAs(mouse));
            Assert.That(cart.Items[0].Quantity, Is.EqualTo(2));
        }

        [Test]
        public void RemoveFromCart_WithExistingProduct_RemovesItemFromCart()
        {
            var cart = new ShoppingCart();
            var keyboard = new Product("Keyboard", 60.0, "Accessories");
            var monitor = new Product("Monitor", 200.0, "Electronics");

            cart.AddToCart(keyboard);
            cart.AddToCart(monitor);

            cart.RemoveFromCart(keyboard);

            Assert.That(cart.Items.Count, Is.EqualTo(1));
            Assert.That(cart.Items[0].Product, Is.SameAs(monitor));
            Assert.That(cart.Items[0].Quantity, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFromCart_WithTwoProducts_DecreasesQuantity()
        {
            var cart = new ShoppingCart();
            var keyboard = new Product("Keyboard", 60.0, "Accessories");
            var monitor = new Product("Monitor", 200.0, "Electronics");

            cart.AddToCart(keyboard);
            cart.AddToCart(monitor);
            cart.AddToCart(keyboard);

            cart.RemoveFromCart(keyboard);

            Assert.That(cart.Items.Count, Is.EqualTo(2));
            Assert.That(cart.Items[0].Product, Is.SameAs(keyboard));
            Assert.That(cart.Items[1].Product, Is.SameAs(monitor));
            Assert.That(cart.Items[0].Quantity, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFromCart_WithNonExistingProduct_DoesNotThrowAndKeepsState()
        {
            var cart = new ShoppingCart();
            var existing = new Product("Laptop", 1300.0, "Electronics");
            var nonExisting = new Product("GPU", 900.0, "Electronics");

            cart.AddToCart(existing);

            Assert.That(() => cart.RemoveFromCart(nonExisting), Throws.Nothing);
            Assert.That(cart.Items.Count, Is.EqualTo(1));
            Assert.That(cart.Items[0].Product, Is.SameAs(existing));
            Assert.That(cart.Items[0].Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GetTotal_OnEmptyCart_ReturnsZero()
        {
            var cart = new ShoppingCart();

            Assert.That(cart.GetTotal(), Is.EqualTo(0.0));
        }

        [Test]
        public void GetTotal_WithMultipleItems_SumsAllPrices()
        {
            var cart = new ShoppingCart();
            cart.AddToCart(new Product("Mouse", 25.5, "Accessories"));
            cart.AddToCart(new Product("Keyboard", 60.0, "Accessories"));
            cart.AddToCart(new Product("Pad", 10.0, "Accessories"));

            var total = cart.GetTotal();

            Assert.That(total, Is.EqualTo(95.5).Within(0.01));
        }

        [Test]
        public void GetTotal_WithSameProductTwice_UsesQuantity()
        {
            var cart = new ShoppingCart();
            Product mouse = new Product("Mouse", 25.5, "Accessories");
            Product keyboard = new Product("Keyboard", 10.0, "Accessories");
            Product pad = new Product("Pad", 10.0, "Accessories");

            cart.AddToCart(mouse);
            cart.AddToCart(mouse);
            cart.AddToCart(keyboard);
            cart.AddToCart(pad);

            var total = cart.GetTotal();

            Assert.That(total, Is.EqualTo(71).Within(0.01));
        }
    }
}
