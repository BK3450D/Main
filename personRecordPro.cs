using System.Collections.Generic;
using System;

namespace ConsoleApp4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dossiers = new Dictionary<string, List<string>>();
            List<Dictionary<string, string>> dossiers2 = new List<Dictionary<string, string>>();

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

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"=>  {menuItems[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"  {menuItems[i]}");
                    }
                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();

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
                else if (pressedKey.Key == ConsoleKey.RightArrow)
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

        static void RequestData(Dictionary<string, List<string>> dossiers)
        {

            Console.Write("Введите ФИО сотрудника: ");
            string fullName = Console.ReadLine();
         
            foreach (var list in dossiers.Values)
            {
                if (list.Contains(fullName))
                {
                    Console.WriteLine("Такое ФИО уже есть.");
                    return;
                }
            }

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            if (!dossiers.ContainsKey(position))
            {
                dossiers[position] = new List<string>();
            }

            dossiers[position].Add(fullName);

            Console.WriteLine("\nДосье добавлено.\n");
        }

        static void DeleteDossier(Dictionary<string, List<string>> dossiers)
        {
            if (dossiers.Count == 0)
            {
                Console.WriteLine("Список досье пуст.");
                return;
            }

            Console.Write("Введите ФИО сотрудника, которого хотите удалить:");
            string fullName = Console.ReadLine();

            foreach (var position in dossiers.Keys)
            {
                if (dossiers[position].Contains(fullName))
                {
                    dossiers[position].Remove(fullName);

                    Console.WriteLine($"Сотрудник: {fullName} с должности {position} удалён.");

                    if (dossiers[position].Count == 0)
                    {
                        dossiers.Remove(position);
                    }
                    return;
                }
            }

            Console.WriteLine("Сотрудник не найден.");

        }
        static void ShowAllDossier(Dictionary<string, List<string>> dossiers)
        {
            if (dossiers.Count == 0)
            {
                Console.WriteLine("Досье отсутствуют.");
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

