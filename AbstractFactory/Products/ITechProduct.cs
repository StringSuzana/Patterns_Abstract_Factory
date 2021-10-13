using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public interface ITechProduct : IProduct
    {
        int GetWarrantyYears();
        void TurnOn();
    }
}
