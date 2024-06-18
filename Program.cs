using System;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Устанавливаем кодировку ввода и вывода консоли на Unicode
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // Создаем и заполняем инвентарь для стола
            string inventoryOwner = "Table";
            StoragePresenter table = CreateInventory(inventoryOwner);

            Item book = new Item("Book");
            Item fetish = new Item("Amulet");
            Item coin = new Item("Coin");

            table.AddItem(coin, 33);
            table.AddItem(book, 1);
            table.AddItem(fetish, 1);

            // Создаем и переносим предметы в инвентарь игрока
            inventoryOwner = "Player";
            StoragePresenter player = CreateInventory(inventoryOwner);

            Console.Clear();

            TakeAllItems(table, player);

            // Отображаем предметы в обоих инвентарях
            table.ShowItems();
            player.ShowItems();
        }

        // Создаем и возвращаем экземпляр StoragePresenter
        private static StoragePresenter CreateInventory(string ownerName)
        {
            IStorageModel model = new StorageModel();
            IStorageView view = new StorageConsoleView(ownerName);

            return new StoragePresenter(model, view);
        }

        // Перемещаем все предметы из одного хранилища в другое
        private static void TakeAllItems(StoragePresenter storageFrom, StoragePresenter storageTo)
        {
            const string RepeateMessage = "try again!";

            while (storageFrom.IsEmpty == false)
            {
                storageFrom.ShowItems();
                storageTo.ShowItems();

                if (TryTakeItemId(storageFrom, out int id))
                {
                    string message = "How many pieces take?";

                    if (TryGetUserUintInput(message, out int count))
                    {
                        if (storageFrom.GetItem(id, count, out IItem item))
                        {
                            storageTo.AddItem(item, count);
                        }
                        else
                        {
                            Console.WriteLine("No such quantity " + RepeateMessage);
                        }
                    }
                    else
                    {
                        Console.WriteLine(RepeateMessage);
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        // Пытается получить идентификатор предмета от пользователя
        private static bool TryTakeItemId(StoragePresenter inventory, out int id)
        {
            bool isSuccess = false;

            string message = "Select product by number";

            if (TryGetUserUintInput(message, out id))
            {
                int itemCount = 0;

                if (inventory.GetItem(id, itemCount, out IItem item))
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        // Пытается получить положительное целое число от пользователя если он вводит какую-то шляпу
        private static bool TryGetUserUintInput(String message, out int userUint)
        {
            bool isSuccess = false;

            Console.WriteLine(message);

            if (int.TryParse(Console.ReadLine(), out userUint))
            {
                isSuccess = true;
            }
            else
            {
                Console.WriteLine("Enter a positive integer!");
            }

            return isSuccess;
        }
    }
}