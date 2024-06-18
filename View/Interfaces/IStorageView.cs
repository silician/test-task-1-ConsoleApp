using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IStorageView
    {
        string OwnerName { get; }
        void LoadSlots(List<ISlotView> slotsView);
        void AddSlot(ISlotView slot);
        void ChangeSlotCount(int id, int Count);
        void DisplayStorage();
        void RemoveSlot(int id);
    }
}
