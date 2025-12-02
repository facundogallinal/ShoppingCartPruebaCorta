namespace Ucu.Poo.eCommerce
{
    public class Coupon2x1 : ICoupon
    {
        public double Discount(ShoppingCart.CartItem item)
        {
            double result = 0;
            if (item.Quantity >= 2)
            {
                if (item.Quantity%2==0)
                {
                    result = item.GetItemTotal() / 2;
                }
                else
                {
                    result = (item.Product.Price * item.Quantity - item.Product.Price) / 2;
                }
            }
            else
            {
                result = item.Product.Price;
            }
            return result;
        }
    }
}