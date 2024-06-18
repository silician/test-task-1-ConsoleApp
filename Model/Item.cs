using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Item : IItem
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IItem Clone()
        {
            return new Item(Name);
        }
    }
}
