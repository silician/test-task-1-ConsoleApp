using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{ 
    internal class StoragePresenter
    {
        private readonly IStorageModel _model;
        private readonly IStorageView _view;

        public bool IsEmpty => _model.IsEmpty;

        // Инициализируем модель и вьюху, а также загружаем слоты и подписывается на события
        public StoragePresenter(IStorageModel model, IStorageView view)
        {
            _model = model;
            _view = view;

            _view.LoadSlots(CreateSlotsView(_model));

            _model.SlotChanged += OnSlotChanged;
            _model.SlotAdded += OnSlotAdded;
            _model.SlotRemoved += OnSlotRemoved;
        }

        public void ShowItems()
        {
            _view.DisplayStorage();
        }
        public void AddItem(IItem item, int count)
        {
            _model.AddItem(item, count);
        }
        public bool GetItem(int id, int count, out IItem item)
        {
            return _model.GetItem(id, count, out item);
        }

        private void OnSlotRemoved(int id)
        {
            _view.RemoveSlot(id);
            _view.DisplayStorage();
        }
        private void OnSlotAdded(ISlotData slotData)
        {
            _view.AddSlot(CreateSlotView(slotData.Id, slotData.Name, slotData.Count));
            _view.DisplayStorage();
        }
        private void OnSlotChanged(ISlotData slotInfo)
        {
            _view.ChangeSlotCount(slotInfo.Id, slotInfo.Count);
            _view.DisplayStorage();
        }

        // Создаем вьюху слотов на основе модели
        private List<ISlotView> CreateSlotsView(IStorageModel model)
        {
            IEnumerable<ISlotData> slots = model.GetSlotsInfo();
            List<ISlotView> slotsView = new List<ISlotView>();

            foreach (ISlotData slot in slots)
            {
                slotsView.Add(CreateSlotView(slot.Id, slot.Name, slot.Count));
            }

            return slotsView;
        }

        // Создаем вьюху одного слота
        private ISlotView CreateSlotView(int id, string name, int count)
        {
            return new SlotConsoleView(id, name, count);
        }
    }
}
