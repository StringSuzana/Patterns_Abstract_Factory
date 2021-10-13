namespace AbstractFactory
{
    public interface IProduct
    {
        string GetName();
        double GetPrice();
        double GetDiscount();
        double GetDiscountPrice();
        string GetShopName();
    }
}
