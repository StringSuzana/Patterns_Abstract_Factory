using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class WestShop : IShop
    {
        public WestShop(string name)
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
