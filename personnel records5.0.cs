﻿using System;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandOutDossier = "1";
            const string CommandShowDossier = "2";
            const string CommandDeletDossier = "3";
            const string CommandFindByLastName = "4";
            const string CommandexitCommand = "5";

            bool isRunning = true;

            string[] fullName = new string[0];
            string[] jobTitle = new string[0];

            while (isRunning)
            {
                Console.WriteLine($"{CommandOutDossier}.Добавить досье.");
                Console.WriteLine($"{CommandShowDossier}.Вывести досье.");
                Console.WriteLine($"{CommandDeletDossier}.Удалить досье.");
                Console.WriteLine($"{CommandFindByLastName}.Поиск по фамилии");
                Console.WriteLine($"{CommandexitCommand}.выход.");
                Console.Write("\nВаш выбор: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandOutDossier:
                        RequestData(ref fullName, ref jobTitle);
                        break;

                    case CommandShowDossier:
                        ShowDossier(fullName, jobTitle, fullName);
                        break;

                    case CommandDeletDossier:
                        RequestDossierRemoval(ref fullName, ref jobTitle);
                        break;

                    case CommandFindByLastName:
                        FindDossier(fullName, jobTitle);
                        break;

                    case CommandexitCommand:
                        isRunning = CompleteTheProgram(isRunning);
                        break;

                    default:
                        Console.WriteLine("\nНеверный выбор, попробуйте снова\n");
                        break;
                }
            }
        }

        static void RequestData(ref string[] fullName, ref string[] jobTitle)
        {
            Console.Write("\nВведите Фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите Отчество: ");
            string surName = Console.ReadLine();

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            string initials = ($"{lastName} {firstName} {surName}");

            fullName = IncreaseArraySize(fullName, initials);
            jobTitle = IncreaseArraySize(jobTitle, position);

            Console.WriteLine("\nДосье добавлено.\n");
        }

        static string[] IncreaseArraySize(string[] dataArray, string initials)
        {
            string[] tempArray = new string[dataArray.Length + 1];

            for (int i = 0; i < dataArray.Length; i++)
            {
                tempArray[i] = dataArray[i];
            }

            tempArray[tempArray.Length - 1] = initials;

            return tempArray;
        }

        static void ShowDossier(string[] names, string[] jobTitle, string[] fullName)
        {
            if (fullName.Length == 0)
            {
                CheckForValidFile(fullName);
            }

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"\n{i + 1}. {names[i]} - {jobTitle[i]}\n");
            }
        }

        static void CheckForValidFile(string[] fullNames)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("\nДосе не найдено\n");
            }
        }

        static void RequestDossierRemoval(ref string[] fullName, ref string[] position)
        {
            if (fullName.Length == 0)
            {
                Console.WriteLine("\nДосе не найдено\n");
                return;
            }

            int number = GetNumber();

            if (number < 1 || number > fullName.Length)
            {
                Console.WriteLine("\nДосье под таким номером нет\n");
                return;
            }

            fullName = ReduceArraySize(fullName, number - 1);
            position = ReduceArraySize(position, number - 1);

            Console.WriteLine("\nДосье удалено\n");
        }

        static string[] ReduceArraySize(string[] fullName, int fileNumber)
        {
            if (fileNumber >= fullName.Length || fileNumber < 0)
            {
                return fullName;
            }

            if (fullName.Length > fileNumber)
            {
                string[] templateArray = new string[fullName.Length - 1];

                for (int i = 0; i < fileNumber; i++)
                {
                    templateArray[i] = fullName[i];
                }
                for (int i = fileNumber + 1; i < fullName.Length; i++)
                {
                    templateArray[i - 1] = fullName[i];
                }
                return templateArray;
            }
            return fullName;
        }

        static void FindDossier(string[] fullName, string[] jobTitle)
        {
            if (fullName.Length == 0)
            {
                CheckForValidFile(fullName);
            }
            else if (fullName.Length != 0)
            {
                bool found = false;

                Console.Write("\nВведите фамилию для поиска: ");

                string userInput = Console.ReadLine();

                for (int i = 0; i < fullName.Length; i++)
                {
                    string name = fullName[i];

                    string[] tempDataArray = name.Split(' ');

                    if (tempDataArray[0].ToLower() == userInput.ToLower())
                    {
                        Console.WriteLine($"\nНайдено:\n{i + 1}. {fullName[i]} - {jobTitle[i]}\n");
                        found = true;
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("\nПо вашему запросу ничего не найдено.\n");
                }
            }
        }

        static bool CompleteTheProgram( bool isRunning)
        {
            Console.Clear();
            Console.WriteLine("Программа завершина");

            isRunning = false;

            return isRunning;
        }

        static int GetNumber()
        {
            int result = 0;

            bool isValue = true;

            while (isValue)
            {
                Console.Write("\nВведите номер досье для удаление:");

                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    isValue = false;
                }
               return result;
            }
            return result;
        }
    }
}