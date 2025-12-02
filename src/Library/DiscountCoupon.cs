namespace Ucu.Poo.eCommerce
{
    public class DiscountCoupon : ICoupon
    {
        public int Percent { get; set; }

        public DiscountCoupon(int percent)
        {
            this.Percent = percent;
        }
        public double Discount(ShoppingCart.CartItem item)
        {
            return(item.GetItemTotal() - item.GetItemTotal() * (this.Percent / 100));
        }
    }
}