using System;

namespace Ucu.Poo.eCommerce
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public Product (string name, double price, string category)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }
    }
}
