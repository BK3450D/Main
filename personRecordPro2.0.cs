using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandOutDossier = 0;
            const int CommandShowDossier = 1;
            const int CommandDeleteDossier = 2;
            const int CommandExit = 3;

            Console.CursorVisible = false;
            
            Dictionary<string, List<string>> dossiers = new Dictionary<string, List<string>>();

            List<string> menuItems = new List<string>()
            {
              "Добавить досье",
              "Вывести досье",
              "Удалить досье",
              "Выход",
            };

            int selectedIndex = 0;

            bool isRun = true;

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
                        case CommandOutDossier:
                            RequestData(dossiers);

                            break;
                        case CommandShowDossier:
                            ShowAllDossier(dossiers);

                            break;
                        case CommandDeleteDossier:
                            DeleteDossier(dossiers);

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

        static void RequestData(Dictionary<string, List<string>> dossiers)
        {
            Console.Write("Введите ФИО сотрудника: ");
            string fullName = Console.ReadLine();

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            if (dossiers.ContainsKey(position) == false)
            {
                dossiers[position] = new List<string>();
            }

            dossiers[position].Add(fullName);

            Console.WriteLine("\nДосье добавлено.\n");
        }

        static void DeleteDossier(Dictionary<string, List<string>> dossiers)
        {
            int count = 0;

            if (dossiers.Count == 0)
            {
                Console.WriteLine("Список досье пуст.");
                return;
            }

            Console.Write("Введите должность для удаления сотрудника:");
            string position = Console.ReadLine();

            var employees = dossiers[position];

            if (dossiers.ContainsKey(position) == false)
            {
                Console.WriteLine("Должность не найдена");
                return;
            }
            if (employees.Count == 0)
            {
                Console.WriteLine("На этой должности нет сотрудников");
                return;
            }

            Console.WriteLine($"Сотрудники на должности {position}:");

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i}: {employees[i]}");
            }

            Console.Write("Введите индекс сотрудника для удаления: ");

            string removedEmployee = Console.ReadLine();

            employees.RemoveAt(count);

            Console.WriteLine($"Сотрудник №{removedEmployee} с должности {position} удалён.");

            if (employees.Count == 0)
            {
                dossiers.Remove(position);
                Console.WriteLine($"Должность {position}была удалена из списка так как на ней нет сотрудников");
            }
        }

        static void ShowAllDossier(Dictionary<string, List<string>> dossiers)
        {
            if (dossiers.Count == 0)
            {
                Console.WriteLine("Список досье пуст.");
                return;
            }

            foreach (var position in dossiers.Keys)
            {
                Console.WriteLine($"Должность: {position}");

                foreach (var fullName in dossiers[position])
                {
                    Console.WriteLine($"ФИО: {fullName}");
                }

                Console.WriteLine();
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для возврата");
            Console.ReadKey();
        }
    }
}
