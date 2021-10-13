using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class EastShop : IShop
    {
        public EastShop(string name)
        {
            this.Name = name;
        }
        private string Name { get; set; }
        public string GetName()
        {
            return Name;
        }
    }
}
