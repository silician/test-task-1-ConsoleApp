using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface ISlot : ISlotData
    {
        IItem Item { get; }
        void IncreaseCount(int value);
        bool DecreaseCount(int value);
    }
}
