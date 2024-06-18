using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SlotConsoleView : ISlotView
    {
        public SlotConsoleView(int id, string name, int count)
        {
            Id = id;
            Name = name;
            Count = count;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Count { get; private set; }

        public void ChangeCount(int count)
        {
            Count = count;
        }
    }
}
