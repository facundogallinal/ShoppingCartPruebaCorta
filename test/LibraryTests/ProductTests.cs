using System;
using NUnit.Framework;

namespace Ucu.Poo.eCommerce.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_WithValidInputs_SetsPropertiesCorrectly()
        {
            string name = "Laptop";
            double price = 1299.99;
            string category = "Electronics";

            var product = new Product(name, price, category);

            Assert.That(product.Name, Is.EqualTo(name));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Category, Is.EqualTo(category));
        }
    }
}
