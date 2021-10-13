using System.Collections.Generic;

namespace AbstractFactory
{
    public interface IServer
    {
        List<IProduct> GetAllProducts(IProductFactory selected_factory);

    }
}