namespace Ucu.Poo.eCommerce
{
    public interface ICoupon
    {
        double Discount(ShoppingCart.CartItem item);
    }
}