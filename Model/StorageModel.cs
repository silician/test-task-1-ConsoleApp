using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StorageModel : IStorageModel
    {
        private List<ISlot> _slots = new List<ISlot>();
        private int _availibleSlotId = 1;

        public event Action<ISlotData> SlotChanged;
        public event Action<ISlotData> SlotAdded;
        public event Action<int> SlotRemoved;

        public bool IsEmpty => _slots.Any() == false;

        // Добавляем предмет в хранилище
        public void AddItem(IItem item, int count)
        {
            if (count == 0)
            {
                Console.WriteLine($"Added: {count} {item.Name}");
                return;
            }

            if (FindItemsSlot(item.Name, out ISlot slot))
            {
                slot.IncreaseCount(count);
                SlotChanged?.Invoke(slot);

                Console.WriteLine();
            }
            else
            {
                ISlot newSlot = CreateSlot(_availibleSlotId, item, count);
                _slots.Add(newSlot);
                _availibleSlotId++;
                SlotAdded?.Invoke(newSlot);
            }
        }

        // Возвращаем информацию о слотах
        public IEnumerable<ISlotData> GetSlotsInfo()
        {
            return _slots;
        }

        // Получаем предмет из хранилища
        public bool GetItem(int id, int count, out IItem item)
        {
            bool isSuccess = false;
            item = null;

            if (FindItemsSlot(id, out ISlot slot))
            {
                if (slot.DecreaseCount(count))
                {
                    isSuccess = true;
                    item = slot.Item;

                    if (count == 0)
                    {
                        return isSuccess;
                    }

                    if (slot.Count == 0)
                    {
                        SlotRemoved?.Invoke(slot.Id);
                        _slots.Remove(slot);
                    }
                    else
                    {
                        SlotChanged?.Invoke(slot);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed to get item by ID");
            }

            return isSuccess;
        }

        // Ищем слот по имени предмета
        private bool FindItemsSlot(string name, out ISlot foundSlot)
        {
            foundSlot = _slots.FirstOrDefault(slot => slot.Name == name);

            return foundSlot != null;
        }

        // Ищем слот по айдишке предмета
        private bool FindItemsSlot(int id, out ISlot foundSlot)
        {
            foundSlot = _slots.FirstOrDefault(slot => slot.Id == id);

            return foundSlot != null;
        }

        // Создаем новый слот
        private ISlot CreateSlot(int id, IItem item, int count)
        {
            return new Slot(id, item, count);
        }

        
    }
}
