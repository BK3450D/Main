using System.Collections.Generic;
using System;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddWord = "1";
            const string CommandRemoveWord = "2";
            const string CommandFindWord = "3";
            const string CommandShowAllWord = "4";
            const string CommandExit = "5";

            bool isRun = true;

            Dictionary<string, string> explanatoryDictionary = new Dictionary<string, string>();

            while (isRun)
            {
                Console.WriteLine($"{CommandAddWord}- Добавить слово");
                Console.WriteLine($"{CommandRemoveWord}- Удалить слово");
                Console.WriteLine($"{CommandFindWord}- Найти значение слово");
                Console.WriteLine($"{CommandShowAllWord}- Показать весь словарь");
                Console.WriteLine($"{CommandExit}-  Выход");

                Console.Write("Ваш выбор: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddWord:
                        AddWord(explanatoryDictionary);
                        break;
                    case CommandRemoveWord:
                        RemoveWord(explanatoryDictionary);
                        break;
                    case CommandFindWord:
                        FindWord(explanatoryDictionary);
                        break;
                    case CommandShowAllWord:
                        ShowAllWord(explanatoryDictionary);
                        break;
                    case CommandExit:
                        isRun = false;
                        break;
                }
            }
        }

        static private void AddWord(Dictionary<string, string> explanatoryDictionary)
        {
            Console.Write("Введите слово которое хотите добавить: ");
            string userInputWord = Console.ReadLine();

            Console.Write($"Введите значение слово {userInputWord}: ");
            string userInputWordMeaning = Console.ReadLine();

            explanatoryDictionary.Add(userInputWord, userInputWordMeaning);
        }

        static private void RemoveWord(Dictionary<string, string> explanatoryDictionary)
        {
            if (explanatoryDictionary.Count == 0)
            {
                IsWordPresent(explanatoryDictionary);
                return;
            }

            Console.Write("Введите слово для удаление: ");
            string userInput = Console.ReadLine().ToLower();

            if (explanatoryDictionary.ContainsKey(userInput))
            {
                explanatoryDictionary.Remove(userInput);

                Console.WriteLine($"Слово: {userInput} удалено.");
            }
            else
            {
                IsWordPresent(explanatoryDictionary);
            }

            Console.WriteLine();
        }

        static void IsWordPresent(Dictionary<string, string> explanatoryDictionary)
        {
            if (explanatoryDictionary.Count == 0)
            {
                Console.Write("Словарь пуст.");
                Console.WriteLine();
                return;
            }
        }

        static void FindWord(Dictionary<string, string> explanatoryDictionary)
        {
            if (explanatoryDictionary.Count == 0)
            {
                IsWordPresent(explanatoryDictionary);
                return;
            }

            Console.Write("Введите слово что бы узнать его значение: ");
            string userInput = Console.ReadLine().ToLower();

            if (explanatoryDictionary.ContainsKey(userInput))
            {
                string word = explanatoryDictionary[userInput];
                Console.WriteLine($"Слово {userInput}: означает: {word}");
            }
            else
            {
                Console.WriteLine($"Слвов: {userInput} не найдено");
            }
        }

        static void ShowAllWord(Dictionary<string, string> explanatoryDictionary)
        {
            if (explanatoryDictionary.Count == 0)
            {
                IsWordPresent(explanatoryDictionary);
                return;
            }
            int count = 0;

            foreach (var key in explanatoryDictionary.Keys)
            {
                Console.WriteLine($"{++count}: {key}");
            }
        }
    }
}
