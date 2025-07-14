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
            Dictionary<string, List<string>> dossiers = new Dictionary<string, List<string>>();

            Console.CursorVisible = false;

            const int CommandOutDossier = 0;
            const int CommandShowDossier = 1;
            const int CommandDeleteDossier = 2;
            const int CommandExit = 3;

            List<string> menuItems = new List<string>()
            {
              "Добавить досье",
              "Вывести досье",
              "Удалить досье",
              "Выход",
            };

            int selectedIndex = 0;

            bool isRunning = true;

            while (isRunning)
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
                            Pause();
                            break;
                        case CommandShowDossier:
                            ShowAllDossier(dossiers);
                            Pause();
                            break;
                        case CommandDeleteDossier:
                            DeleteDossier(dossiers);
                            Pause();
                            break;
                        case CommandExit:
                            isRunning = false;
                            break;
                    }
                }
            }
        }

        private static void GetPressKey(ConsoleKeyInfo pressedKey, ref int selectedIndex, List<string> menuItems)
        {
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;

                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
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

