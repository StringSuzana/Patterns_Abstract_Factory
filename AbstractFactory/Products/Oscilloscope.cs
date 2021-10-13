using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class Oscilloscope : BaseProduct, ITechProduct
    {
        public int Warranty { get; set; }
        public double GetDiscount() => Discount;

        public double GetDiscountPrice() => GetDiscountPrice();

        public string GetName() => Name;

        public double GetPrice() => Price;

        public bool IsReturnable() => true;

        public string GetShopName() => Shop.GetName();

        public int GetWarrantyYears() => Warranty;

        public void TurnOn()
        {
            Console.WriteLine("Osciloscope turned on.");
        }

        public Oscilloscope(IFactoryType factory_type, string name, string price, string discount, string warranty)
        {
            Name = name;
            Price = double.Parse(price);
            Discount = double.Parse(discount);
            Shop = factory_type.GetShopType();
            Warranty =  (!string.IsNullOrEmpty(warranty))? int.Parse(warranty) : 0;
        }
    }
}
