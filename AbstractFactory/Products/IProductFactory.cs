using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string name, string price, string discount, string warranty = "");
        IRegularProduct CreateRegularProduct(string name, string price, string discount);
        ITechProduct CreateTechProduct(string name, string price, string discount, string warranty);

    }
    public interface IFactoryType
    {
        public IShop GetShopType();
    }
    public abstract class BaseProductFactory : IProductFactory, IFactoryType
    {
        public abstract IShop GetShopType();
        public IProduct CreateProduct(string name, string price, string discount, string warranty = "")
        {
            switch (name.ToUpper())
            {
                case nameof(ProductEnum.BALL):
                case nameof(ProductEnum.CAKE):
                case nameof(ProductEnum.SHIRT):
                    return CreateRegularProduct(name, price, discount);
                case nameof(ProductEnum.OSCILLOSCOPE):
                    return CreateTechProduct(name, price, discount, warranty);

                default:
                    return null;
            }
        }

        public IRegularProduct CreateRegularProduct(string name, string price, string discount)
        {
            switch (name.ToUpper())
            {
                case nameof(ProductEnum.BALL):
                    return new Ball(this, name, price, discount);
                case nameof(ProductEnum.CAKE):
                    return new Cake(this, name, price, discount);
                case nameof(ProductEnum.SHIRT):
                    return new Shirt(this, name, price, discount);

                default:
                    return null;
            }
        }
        public ITechProduct CreateTechProduct(string name, string price, string discount, string warranty)
        {
            switch (name.ToUpper())
            {
                case nameof(ProductEnum.OSCILLOSCOPE):
                    return new Oscilloscope(this, name, price, discount, warranty);

                default:
                    return null;
            }
        }
    }

    public class WestFactory : BaseProductFactory
    {
        public override IShop GetShopType()
        {
            return new WestShop("City centre west");
        }
    }
    public class EastFactory : BaseProductFactory
    {
        public override IShop GetShopType()
        {
            return new WestShop("City centre east");
        }
    }
}
