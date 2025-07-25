using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu menu = new Menu();
            menu.Work();
        }
    }

    class UserInfo
    {
        private int _id;
        private string _nickName;
        private int _level;

        public UserInfo(int id, string nickName, int level)
        {
            _id = id;
            _nickName = nickName;
            _level = level;
            IsBanned = false;
        }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }

        public string GetInfoPlayer()
        {
            return $"ID: {_id} | Имя: {_nickName} | Уровень: {_level} | Забанен: ";
        }
    }

    class Database
    {
        public Dictionary<int, UserInfo> users = new Dictionary<int, UserInfo>();
        private int _nextId = 0;

        public bool IsEmpty => users.Count == 0;

        public void AddUser(string nickName, int level)
        {
            UserInfo newUser = new UserInfo(_nextId, nickName, level);
            users.Add(_nextId, newUser);
            Console.WriteLine($"Игрок добавлен с ID: {_nextId}");
            _nextId++;
        }

        public bool BanUser(int id)
        {
            if (users.TryGetValue(id, out UserInfo user))
            {
                user.Ban();
                return true;
            }

            return false;
        }

        public bool UnbanUser(int id)
        {
            if (users.TryGetValue(id, out UserInfo user))
            {
                user.Unban();
                return true;
            }

            return false;
        }

        public bool RemoveUser(int id)
        {
            return users.Remove(id);
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
                Console.Write(user.GetInfoPlayer());

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

        public bool TryGetPlayer(out int idPlayer)
        {
            Console.Write("Введите ID игрока: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out idPlayer))
            {
                if (users.ContainsKey(idPlayer))
                    return true;
                else
                {
                    Console.WriteLine($"Указанный ID - {input}  не существует");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Введите число");
                return false;
            }
        }
    }

    class Menu
    {
        private Database _database = new Database();

        public void Work()
        {
            const int CommandAddUser = 0;
            const int CommandShowUsers = 1;
            const int CommandBanUser = 2;
            const int CommandUnbanUser = 3;
            const int CommandDeleteUser = 4;
            const int CommandExit = 5;

            ConsoleKey reghtMoveCommand = ConsoleKey.RightArrow;
            ConsoleKey EnterCommand = ConsoleKey.Enter;

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

                if (pressedKey.Key == reghtMoveCommand || pressedKey.Key == EnterCommand)
                {
                    Console.Clear();

                    switch (selectedIndex)
                    {
                        case CommandAddUser:
                            RequestData();
                            break;
                        case CommandShowUsers:
                            _database.ShowAllUsers();
                            break;
                        case CommandBanUser:
                            BanUser();
                            break;
                        case CommandUnbanUser:
                            UnbanUser();
                            break;
                        case CommandDeleteUser:
                            RemoveUser();
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
                selectedIndex = (selectedIndex - 1 + menuItems.Count) % menuItems.Count;
            }
            else if (pressedKey.Key == downMoveCommand)
            {
                selectedIndex = (selectedIndex + 1) % menuItems.Count;
            }
        }

        private static void DrawMenu(List<string> menuItems, int selectedIndex)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                    Console.WriteLine($"=> {menuItems[i]}");
                else
                    Console.WriteLine($"   {menuItems[i]}");
            }
        }

        private void RequestData()
        {
            const int MinLevel = 1;
            const int MaxLevel = 80;

            Console.Write("Введите имя игрока: ");
            string nickName = Console.ReadLine();

            Console.Write("Введите уровень игрока (1–80): ");
            string inputLevel = Console.ReadLine();

            if (int.TryParse(inputLevel, out int level))
            {
                if (level < MinLevel || level > MaxLevel)
                {
                    Console.WriteLine($"Ошибка: Уровень должен быть от {MinLevel} до {MaxLevel}.");
                    return;
                }

                _database.AddUser(nickName, level);
            }
        }

        private void BanUser()
        {
            if (_database.IsEmpty)
            {
                Console.WriteLine("База данных пуста.");
                return;
            }

            if (_database.TryGetPlayer(out int id))
            {
                if (_database.BanUser(id))
                    Console.WriteLine($"Игрок с ID - {id} забанен.");
                else
                    Console.WriteLine($"Игрок с таким c ID - {id} не найден.");
            }
        }

        private void UnbanUser()
        {
            if (_database.IsEmpty)
            {
                Console.WriteLine("База данных пуста.");
                return;
            }

            if (_database.TryGetPlayer(out int id))
            {
                if (_database.UnbanUser(id))
                    Console.WriteLine($"Игрок с ID - {id} разбанен.");
                else
                    Console.WriteLine($"Игрок с таким c ID - {id} не найден.");
            }
        }


        private void RemoveUser()
        {
            if (_database.IsEmpty)
            {
                Console.WriteLine("База данных пуста.");
                return;
            }

            if (_database.TryGetPlayer(out int id))
            {
                if (_database.RemoveUser(id))
                    Console.WriteLine($"Игрок с ID - {id} удалён .");
                else
                    Console.WriteLine($"Игрок с таким c ID - {id} не найден.");
            }
        }

        private void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }


    }
}






