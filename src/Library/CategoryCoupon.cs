namespace Ucu.Poo.eCommerce
{
    public class CategoryCoupon : ICoupon
    {
        public string Category { get; set; }
        public int Percent { get; set; }

        public CategoryCoupon(string category,int percent)
        {
            this.Category = category;
            this.Percent = percent;
        }
        public double Discount(ShoppingCart.CartItem item)
        {
            double result = item.GetItemTotal();
            if (item.Product.Category == this.Category)
            {
                result = result - result * (this.Percent / 100);
            }

            return result;
        }
    }
}