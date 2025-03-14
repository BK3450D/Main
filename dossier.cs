using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            string firstName;
            string lastName;
            string surName;
            string position;
            string initials;

            int userCount = 0;

            bool isRunning = true;

            string[] fullName = new string[0];
            string[] jobTitle = new string[0];

            while (isRunning)
            {
                Console.WriteLine("1.Добавить досье.");
                Console.WriteLine("2.Вывести досье.");
                Console.WriteLine("3.Удалить досье.");
                Console.WriteLine("4.Поиск по фамилии");
                Console.WriteLine("5.выход.");

                Console.Write("\nВаш выбор: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandOutDossier:

                        RequestData(out firstName, out lastName, out surName, out position, out initials);

                        FillingInData(ref fullName, initials);

                        FillingInData(ref jobTitle, position);

                        Console.WriteLine("\nДосье добавлено.\n");
                        break;

                    case CommandShowDossier:

                        if (fullName.Length == 0)
                        {
                            ListIsEmpty(fullName);
                        }

                        ShowDossier(fullName, jobTitle, userCount);
                        break;


                    case CommandDeletDossier:

                        RequestDossierRemoval(ref fullName, ref jobTitle, ref userCount);
                        break;

                    case CommandFindByLastName:
                        FindDossier(fullName, jobTitle);
                        break;

                    case CommandexitCommand:

                        Console.Clear();
                        Console.WriteLine("Программа завершина");
                        isRunning = false;

                        break;

                    default:
                        Console.WriteLine("\nНеверный выбор, попробуйте снова\n");
                        break;
                }
            }
        }
        static void RequestData(out string firstName, out string lastName, out string surName, out string position, out string initials)
        {
            Console.Write("\nВведите Фамилию: ");
            lastName = Console.ReadLine();

            Console.Write("Введите имя: ");
            firstName = Console.ReadLine();

            Console.Write("Введите Отчество: ");
            surName = Console.ReadLine();

            Console.Write("Введите должность: ");
            position = Console.ReadLine();

            initials = ($"{lastName} {firstName} {surName}");
        }
        static void FillingInData(ref string[] dataArray, string initials)
        {
            string[] tempArray = new string[dataArray.Length + 1];

            for (int i = 0; i < dataArray.Length; i++)
            {
                tempArray[i] = dataArray[i];
            }

            tempArray[tempArray.Length - 1] = initials;

            dataArray = tempArray;
        }
        static void ShowDossier(string[] names, string[] jobTitle, int index)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"\n{i + index + 1}. {names[i]} - {jobTitle[i]}\n");
            }
        }
        static void ListIsEmpty(string[] fullNames)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("\nДосе не найдено\n");
            }
        }
        static void RequestDossierRemoval(ref string[] fullName, ref string[] position, ref int deletIndex)
        {
            if (fullName.Length == 0)
            {
                ListIsEmpty(fullName);
            }

            else if (fullName.Length > deletIndex)
            {
                Console.Write("\nВведите номер досье для удаление:");

                deletIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                deletionOfDossier(ref fullName, deletIndex);

                deletionOfDossier(ref position, deletIndex);

                Console.WriteLine("\nДосье удалено\n");
            }
        }
        static void deletionOfDossier(ref string[] dataArray, int deletIndex)
        {
            if (dataArray.Length > deletIndex)
            {
                string[] templateArray = new string[dataArray.Length - 1];

                for (int i = 0; i < deletIndex; i++)
                {
                    templateArray[i] = dataArray[i];
                }

                for (int i = deletIndex + 1; i < dataArray.Length; i++)
                {
                    templateArray[i - 1] = dataArray[i];
                }

                dataArray = templateArray;
            }
        }
        static void FindDossier(string[] fullName, string[] jobTitle)
        {
            if (fullName.Length == 0)
            {
                ListIsEmpty(fullName);
            }

            else if (fullName.Length != 0)
            {
                Console.Write("Введите фамилию для поискаа: ");

                string userInput = Console.ReadLine();

                for (int i = 0; i < fullName.Length; i++)
                {
                    string name = fullName[i];

                    string[] tempDataArray = name.Split(' ');

                    if (tempDataArray[0].ToLower() == userInput.ToLower())
                    {
                        Console.WriteLine($"\nНайдено:\n{i + 1}. {fullName[i]} - {jobTitle[i]}\n");
                    }
                }
            }
        }
    }
}
