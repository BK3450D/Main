using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu Menu = new Menu();
            Menu.Work();
        }
    }   
}

class Menu
{
    private class UserInfo
    {
        private int Id;
        private string NickName;
        private int Level;
        public bool IsBanned { get; private set; }
        public UserInfo(int id, string nickName, int level)
        {
            Id = id;
            NickName = nickName;
            Level = level;
            IsBanned = false;
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
        public string GetUserInfo()
        {
           return $"ID: {Id}| Имя: {NickName}| Уровень: {Level}| Забанен:";
        }
    }

    private class Database
    {
        private Dictionary<int, UserInfo> users = new Dictionary<int, UserInfo>();
        private int nextId = 0;

        public void AddUser(string nickName, int level)
        {
            UserInfo newUser = new UserInfo(nextId, nickName, level);
            users.Add(nextId, newUser);
            Console.WriteLine($"Игрок добавлен с ID: {nextId}");
            nextId++;
        }

        public bool IsEmpty()
        {
            return users.Count == 0;
        }

        public void ShowAllUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
                return;
            }

            foreach (var user in users.Values)
            {
                Console.Write(user.GetUserInfo());

                if (user.IsBanned)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Да");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Нет");
                }

                Console.ResetColor();
            }
        }

        public void RemoveUser(int id)
        {
            if (users.Remove(id))
            {
                Console.WriteLine($"Игрок с ID {id} удалён из базы.");
            }
            else
            {
                Console.WriteLine("Игрок с таким ID не найден.");
            }
        }

        public void BanUser(int id)
        {
            if (users.ContainsKey(id))
            {
                users[id].Ban();
                Console.WriteLine($"Игрок с ID {id} забанен.");
            }
            else
            {
                Console.WriteLine("Игрок с таким ID не найден.");
            }
        }

        public void UnbanUser(int id)
        {
            if (users.ContainsKey(id))
            {
                users[id].Unban();
                Console.WriteLine($"Игрок с ID {id} разбанен.");
            }
            else
            {
                Console.WriteLine("Игрок с таким ID не найден.");
            }
        }
    }

    Database database = new Database();

    public void Work()
    {
        const int CommandAddUser = 0;
        const int CommandShowUsers = 1;
        const int CommandBanUser = 2;
        const int CommandUnbanUser = 3;
        const int CommandDeleteUser = 4;
        const int CommandExit = 5;

        List<string> menuItems = new List<string>()
            {
              "Добавить игрока",
               "Показать всех игроков",
               "Забанить игрока",
               "Разбанить игрока",
                "Удалить игрока",
               "Выход"
            };

        bool isRun = true;
        int selectedIndex = 0;

        while (isRun)
        {
            Console.Clear();

            DrawMenu(menuItems, selectedIndex);
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            GetPressKey(pressedKey, ref selectedIndex, menuItems);

            if (pressedKey.Key == ConsoleKey.RightArrow || pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                switch (selectedIndex)
                {
                    case CommandAddUser:
                        RequestData();
                        break;
                    case CommandShowUsers:
                        database.ShowAllUsers();
                        break;
                    case CommandBanUser:
                        BanUser();
                        break;
                    case CommandUnbanUser:
                        UnbanUser();
                        break;
                    case CommandDeleteUser:
                        break;
                    case CommandExit:
                        isRun = false;
                        break;
                }

                Pause();
            }
        }
    }
    private static void GetPressKey(ConsoleKeyInfo pressedKey, ref int selectedIndex, List<string> menuItems)
    {
        ConsoleKey upMoveCommand = ConsoleKey.UpArrow;
        ConsoleKey downMoveCommand = ConsoleKey.DownArrow;

        if (pressedKey.Key == upMoveCommand)
        {
            selectedIndex--;

            if (selectedIndex < 0)
            {
                selectedIndex = menuItems.Count - 1;
            }
        }
        else if (pressedKey.Key == downMoveCommand)
        {
            selectedIndex++;

            if (selectedIndex >= menuItems.Count)
            {
                selectedIndex = 0;
            }
        }
    }

    static void DrawMenu(List<string> menuItems, int selectedIndex)
    {
        Console.Clear();
        for (int i = 0; i < menuItems.Count; i++)
        {
            if (i == selectedIndex)
                Console.WriteLine($"=> {menuItems[i]}");
            else
                Console.WriteLine($" {menuItems[i]}");
        }
    }

    private void RequestData()
    {
        Console.Write("Введите имя игрока: ");
        string nickName = Console.ReadLine();

        Console.Write("Введите уровень игрока(1-80): ");
        string inputLevel = Console.ReadLine();

        if (int.TryParse(inputLevel, out int level))
        {
            if (level < 1 || level > 80)
            {
                Console.WriteLine("Максимальный уровень 80.");
                return;
            }

            database.AddUser(nickName, level);
        }
        else
        {
            Console.WriteLine("Некорректный ввод уровня.");
        }
    }

    private void BanUser()
    {
        if (database.IsEmpty())
        {
            Console.WriteLine("База данных пуста.");
            return;
        }

        Console.Write("Введите ID игрока для бана: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int id))
        {
            database.BanUser(id);
        }
        else
        {
            Console.WriteLine("Некорректный ввод ID.");
        }
    }

    private void UnbanUser()
    {
        if (database.IsEmpty())
        {
            Console.WriteLine("База данных пуста.");
            return;
        }

        Console.Write("Введите ID игрока для разбана: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int id))
        {
            database.UnbanUser(id);
        }
        else
        {
            Console.WriteLine("Некорректный ввод ID.");
        }
    }
    private void Pause()
    {
        Console.WriteLine("\nНажмите любую клавишу для возврата");
        Console.ReadKey();
    }
}


