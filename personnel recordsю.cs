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
                Console.WriteLine("4.Поиск по фамилии.");
                Console.WriteLine("5.выход.");
                Console.Write("Ваш выбор: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandOutDossier:

                        FilOutDossier(ref fullName, ref jobTitle);

                        break;

                    case CommandShowDossier:

                        ShowDossier(fullName, jobTitle, ref serialNumber);

                        break;
                    case CommandDeletDossier:

                        DeleteDossier(ref fullName, ref jobTitle);

                        break;

                    case CommandFindByLastName:

                        FindLastName(fullName);

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

            char symbol = ' ';

            string names = firstName  + symbol + lastName + symbol + surname;

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
        static void ShowDossier(string[] names, string[] jobTitle, ref int index)
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
            string[] tempfullUsersNames = new string[fullName.Length - 1];
            string[] tempJobTitle = new string[jobTitle.Length - 1];

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
            Console.WriteLine($"Досбе номер {deleteIndex + 1} удаленно.");
            Console.WriteLine();
        }
        static void FindLastName(string[] fullNames)
        {
            string userInput;

            Console.Write("Введите фамлиию для поиска: ");

            userInput = Console.ReadLine();

            bool isFound = false;

            for (int i = 0; i < fullNames.Length; i++)
            {


                string[] splitPartOfName = fullNames[i].Split(' ');

                if (splitPartOfName[0].ToLower() == userInput.ToLower())
                {
                    Console.WriteLine($"{i + 1}. {fullNames[i]}");
                    isFound = true;
                }

            }





        }

    }
}

