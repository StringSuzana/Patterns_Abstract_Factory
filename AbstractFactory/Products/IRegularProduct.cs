using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public interface IRegularProduct : IProduct
    {
        public bool IsReusable();
    }
}
