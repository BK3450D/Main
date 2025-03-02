using System;
using System.Collections.Generic;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandOutDossier = "1"; //Добавить досье
            const string CommandShowDossier = "2"; // вывести  досье
            const string CommandDeletDossier = "3"; // удалить досье
            const string CommandFindByLastName = "4"; // поиск по фамилии

            string exitCommand = "5";

            string[] fullName = new string[0];
            string[] jobTitle = new string[0];

            int serialNumber = 1;
            int index;

            bool CanWork = true;

            while (CanWork)
            {
                Console.WriteLine("1.Добавить досье.");
                Console.WriteLine("2.Вывести досье.");
                Console.WriteLine("3.Удалить досье.");
                Console.WriteLine("4.Поиск по Ф.И.О.");
                Console.WriteLine("5.выход.");
                Console.WriteLine();
                Console.Write("Ваш выбор: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandOutDossier:

                        FilOutDossier(ref fullName, ref jobTitle);
                        break;

                    case CommandShowDossier:
                        if (fullName.Length == 0)
                        {
                            ListIsEmpty(fullName);
                        }

                        ShowDossier(fullName, jobTitle, serialNumber);
                        break;

                    case CommandDeletDossier:
                        DeleteDossier(ref fullName, ref jobTitle);
                        break;

                    case CommandFindByLastName:
                        FindLastName(fullName, jobTitle);
                        break;

                    default:
                        Console.WriteLine();
                        Console.Write("Неверный выбор, попробуйте снова");
                        Console.WriteLine();
                        break;
                }

                if (userInput == exitCommand)
                {
                    Console.WriteLine("Программа завершина.");
                    CanWork = false;
                }
            }
        }
        static void FilOutDossier(ref string[] fullName, ref string[] jobTitle) // заполнить досье
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите Фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите Отчество: ");
            string surname = Console.ReadLine();

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            string names = ($"{firstName} {lastName} {surname}");

            string[] tempfullName = new string[fullName.Length + 1];
            string[] tempJobTitle = new string[jobTitle.Length + 1];

            for (int i = 0; i < fullName.Length; i++)
            {
                tempfullName[i] = fullName[i];
                tempJobTitle[i] = jobTitle[i];
            }

            tempfullName[tempfullName.Length - 1] = names;
            tempJobTitle[tempJobTitle.Length - 1] = position;

            fullName = tempfullName;
            jobTitle = tempJobTitle;

            Console.WriteLine();
            Console.WriteLine("Досье добавлено.");
            Console.WriteLine();
        }
        static void ShowDossier(string[] names, string[] jobTitle, int index = 1)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i + index}. {names[i]} - {jobTitle[i]}");
                Console.WriteLine();
            }
        }
        static void DeleteDossier(ref string[] fullName, ref string[] jobTitle)
        {
            if (fullName.Length == 0)
            {
                ListIsEmpty(fullName);
            }

            else if (fullName.Length != 0)
            {
                string[] tempfullUsersNames = new string[fullName.Length - 1];
                string[] tempJobTitle = new string[jobTitle.Length - 1];

                Console.WriteLine();
                Console.Write("Введите номер досье для удаление: ");

                int deleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                for (int i = 0; i < deleteIndex; i++)
                {

                    if (deleteIndex == fullName.Length - 1)
                    {
                        Console.WriteLine();
                    }

                    tempfullUsersNames[i] = fullName[i];
                    tempJobTitle[i] = jobTitle[i];
                }

                for (int i = deleteIndex + 1; i < fullName.Length; i++)
                {
                    tempfullUsersNames[i - 1] = fullName[i];
                    tempJobTitle[i - 1] = jobTitle[i];
                }

                fullName = tempfullUsersNames;
                jobTitle = tempJobTitle;

                Console.WriteLine();
                Console.WriteLine($"Досье номер {deleteIndex + 1} удаленно.");
                Console.WriteLine();
            }
        }
        static void FindLastName(string[] fullNames, string[] jobTitle)
        {
            if (fullNames.Length == 0)
            {
                ListIsEmpty(fullNames);
            }

            else
            {
                string userInput;

                Console.WriteLine();
                Console.Write("Введите Ф.И.О. для поиска: ");

                userInput = Console.ReadLine();

                bool isFound = false;

                for (int i = 0; i < fullNames.Length; i++)
                {
                    if (fullNames[i].Contains(userInput))
                    {
                        ShowDossier(fullNames, jobTitle, i);
                    }
                    else
                    {
                        Console.WriteLine("Ф.И.О не найдено.");
                    }
                }
            }
        }
        static void ListIsEmpty(string[] fullNames)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Список досье пуст");
                Console.WriteLine();
            }
        }
    }
}

