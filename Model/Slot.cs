using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Slot : ISlot
    {
        private IItem _item;

        public Slot(int id, IItem item, int count)
        {
            _item = item;
            Id = id;
            Count = count;
        }

        public string Name => _item.Name;
        public IItem Item => _item.Clone();
        public int Id { get; private set; }
        public int Count { get; private set; }

        public void IncreaseCount(int value)
        {
            Count += value;
        }

        public bool DecreaseCount(int value)
        {
            bool isDecrease = false;

            if (Count < value)
            {
                return isDecrease;
            }
            else
            {
                Count -= value;
                isDecrease = true;
            }

            return isDecrease;
        }
    }
}
