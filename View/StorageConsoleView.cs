using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StorageConsoleView : IStorageView
    {
        private List<ISlotView> _slotsView = new List<ISlotView>();

        public StorageConsoleView(string ownerName)
        {
            OwnerName = ownerName;
        }

        public string OwnerName { get; private set; }

        // Загружаем слоты в вьюху
        public void LoadSlots(List<ISlotView> slotsView)
        {
            _slotsView = slotsView;
        }

        // Добавляем новый слот в вьюху
        public void AddSlot(ISlotView slot)
        {
            _slotsView.Add(slot);
        }

        // Изменяем количество предметов в слоте
        public void ChangeSlotCount(int id, int Count)
        {
            if (FindSlot(id, out ISlotView slotView))
            {
                slotView.ChangeCount(Count);
            }
        }

        // Удаляет слот из вьюхи
        public void RemoveSlot(int id)
        {
            if (FindSlot(id, out ISlotView slotView))
            {
                _slotsView.Remove(slotView);
            }
        }

        // Отображаем содержимое хранилища в консоли
        public void DisplayStorage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterText($"----- {OwnerName} storage: -----");
            Console.ForegroundColor = ConsoleColor.White;

            if (_slotsView.Any() == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                CenterText(" ===> Storage is empty! <===");
                Console.ForegroundColor = ConsoleColor.White;
            }

            foreach (ISlotView slotView in _slotsView)
            {
                CenterText($"ID: {slotView.Id}, --> {slotView.Name}, {slotView.Count} pcs <--");
            }

            Console.WriteLine();
        }

        // Находим слот по айдишке
        private bool FindSlot(int id, out ISlotView foundSlot)
        {
            foundSlot = _slotsView.FirstOrDefault(slot => slot.Id == id);

            return foundSlot != null;
        }

        // Центрируем текст в консоли чтоб было красиво
        private void CenterText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int stringWidth = text.Length;
            int spaces = (windowWidth - stringWidth) / 2;

            string padding = new string(' ', spaces);
            Console.WriteLine(padding + text);
        }
    }
}
