using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface ISlotView
    {
        int Id { get; }
        string Name { get; }
        int Count { get; }

        void ChangeCount(int count);
    }
}
