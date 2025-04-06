using System;

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

            bool isRun = true;

            string[] fullNames = new string[0];
            string[] jobTitles = new string[0];

            while (isRun)
            {
                Console.WriteLine($"{CommandOutDossier}. Добавить досье.");
                Console.WriteLine($"{CommandShowDossier}. Вывести досье.");
                Console.WriteLine($"{CommandDeletDossier}. Удалить досье.");
                Console.WriteLine($"{CommandFindByLastName}. Поиск по фамилии");
                Console.WriteLine($"{CommandexitCommand}. Выход.");

                Console.Write("\nВаш выбор: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandOutDossier:
                        RequestData(ref fullNames, ref jobTitles);
                        break;
                    case CommandShowDossier:
                        ShowDossier(fullNames, jobTitles);
                        break;
                    case CommandDeletDossier:
                        RequestDossierRemoval(ref fullNames, ref jobTitles);
                        break;
                    case CommandFindByLastName:
                        FindDossier(fullNames, jobTitles);
                        break;
                    case CommandexitCommand:
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("\nНеверный выбор, попробуйте снова\n");
                        break;
                }
            }
        }

        static void RequestData(ref string[] fullNames, ref string[] jobTitles)
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

            fullNames = IncreaseArraySize(fullNames, initials);
            jobTitles = IncreaseArraySize(jobTitles, position);

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

        static void ShowDossier(string[] fullNames, string[] jobTitles)
        {
            if (fullNames.Length == 0)
            {
                IsDossierPresent(fullNames);
            }

            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine($"\n{i + 1}. {fullNames[i]} - {jobTitles[i]}\n");
            }
        }

        static void IsDossierPresent(string[] fullNames)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("\nДосье не найдено\n");
            }
        }

        static void RequestDossierRemoval(ref string[] fullNames, ref string[] position)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("\nДосье не найдено\n");
                return;
            }

            int number = GetNumber();

            if (number < 1 || number > fullNames.Length)
            {
                Console.WriteLine("\nДосье под таким номером нет\n");
                return;
            }

            fullNames = ReduceArraySize(fullNames, number - 1);
            position = ReduceArraySize(position, number - 1);

            Console.WriteLine("\nДосье удалено\n");
        }

        static string[] ReduceArraySize(string[] fullNames, int fileNumber)
        {
            if (fileNumber >= fullNames.Length || fileNumber < 0)
            {
                return fullNames;
            }

            string[] templateArray = new string[fullNames.Length - 1];

            for (int i = 0; i < fileNumber; i++)
            {
                templateArray[i] = fullNames[i];
            }

            for (int i = fileNumber + 1; i < fullNames.Length; i++)
            {
                templateArray[i - 1] = fullNames[i];
            }

            return templateArray;
        }

        static void FindDossier(string[] fullNames, string[] jobTitles)
        {
            if (fullNames.Length == 0)
            {
                IsDossierPresent(fullNames);
            }
            else if (fullNames.Length != 0)
            {
                bool Isfound = false;

                Console.Write("\nВведите фамилию для поиска: ");

                string userInput = Console.ReadLine();

                for (int i = 0; i < fullNames.Length; i++)
                {
                    string name = fullNames[i];

                    string[] tempDataArray = name.Split();

                    if (tempDataArray[0].ToLower() == userInput.ToLower())
                    {
                        Console.WriteLine($"\nНайдено: {i + 1}. {fullNames[i]} - {jobTitles[i]}\n");
                        Isfound = true;
                    }
                }
                if (Isfound == false)
                {
                    Console.WriteLine("\nПо вашему запросу ничего не найдено.\n");
                }
            }
        }

        static int GetNumber()
        {
            int result = 0;

            bool isValue = true;

            while (isValue)
            {
                Console.Write("\nВведите номер досье для удаления: ");
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
