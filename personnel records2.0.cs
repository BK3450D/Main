using System;
using System.Reflection.Emit;

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

            
            string position;
            string initials;
            string firstName;
            string lastName;
            string surName;
    
            int userCount = 0;

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
                        RequestData(ref fullName,ref jobTitle);
                        break;

                    case CommandShowDossier:
                        ShowDossier(fullName, jobTitle, userCount, fullName);
                        break;

                    case CommandDeletDossier:
                        RequestDossierRemoval(ref fullName, ref jobTitle, ref userCount);
                        break;

                    case CommandFindByLastName:
                        FindDossier(fullName, jobTitle);
                        break;

                    case CommandexitCommand:
                        CompleteTheProgram(ref isRunning);
                        break;

                    default:
                        Console.WriteLine("\nНеверный выбор, попробуйте снова\n");
                        break;
                }
            }
        }

        static void RequestData( ref string[] fullName, ref string[] jobTitle)
        {
            Console.Write("\nВведите Фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите имя: ");
             string firstName = Console.ReadLine();

            Console.Write("Введите Отчество: ");
            string surName = Console.ReadLine();

            Console.Write("Введите должность: ");
            string  position = Console.ReadLine();

            string initials = ($"{lastName} {firstName} {surName}");

            fullName = IncreaseArraySize( fullName, initials);

            jobTitle = IncreaseArraySize( jobTitle, position);

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

        static void ShowDossier(string[] names, string[] jobTitle, int index, string[] fullName)
        {
            if (fullName.Length == 0)
            {
                CheckForValidFile(fullName);
            }

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"\n{i + index + 1}. {names[i]} - {jobTitle[i]}\n");
            }
        }

        static void CheckForValidFile(string[] fullNames)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("\nДосе не найдено\n");
            }
        }

        static void RequestDossierRemoval(ref string[] fullName, ref string[] position, ref int fileNumber)
        {
            if (fullName.Length == 0)
            {
                CheckForValidFile(fullName);
            }
            else if (fullName.Length > fileNumber)
            {
                int number = GetNumber() -1;

                ReduceArraySize(ref fullName, fileNumber);
                ReduceArraySize(ref position, fileNumber);

                Console.WriteLine("\nДосье удалено\n");
            }
        }

        static void ReduceArraySize(ref string[] dataArray, int fileNumber)
        {
            if (dataArray.Length > fileNumber)
            {
                string[] templateArray = new string[dataArray.Length - 1];

                for (int i = 0; i < fileNumber; i++)
                {
                    templateArray[i] = dataArray[i];
                }

                for (int i = fileNumber + 1; i < dataArray.Length; i++)
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

        static void CompleteTheProgram(ref bool isRunning)
        {
            Console.Clear();
            Console.WriteLine("Программа завершина");
            isRunning = false;
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
            }
            return result;
        }
    }
}