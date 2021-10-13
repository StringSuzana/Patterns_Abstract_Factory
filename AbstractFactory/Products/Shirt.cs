using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public class Shirt : BaseProduct, IRegularProduct
    {
        public double GetDiscount() => Discount;

        public double GetDiscountPrice() => GetDiscountPrice();

        public string GetName() => Name;

        public double GetPrice() => Price;

        public bool IsReusable() => true;

        public string GetShopName() => Shop.GetName();

        public Shirt(IFactoryType factory_type, string name, string price, string discount)
        {
            Name = name;
            Price = double.Parse(price);
            Discount = double.Parse(discount);
            Shop = factory_type.GetShopType();
        }
    }
}
