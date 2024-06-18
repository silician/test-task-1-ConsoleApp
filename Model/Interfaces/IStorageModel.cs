using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IStorageModel
    {
        event Action<ISlotData> SlotAdded;
        event Action<ISlotData> SlotChanged;
        event Action<int> SlotRemoved;

        bool IsEmpty { get; }
        void AddItem(IItem item, int count);
        IEnumerable<ISlotData> GetSlotsInfo();
        bool GetItem(int id, int count, out IItem item);
    }
}
