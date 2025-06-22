using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            string exitCommand = "exit";
            string sumCommand = "sum";

            bool isWork = true;

            Console.WriteLine($"Введите {sumCommand} что бы сложить числа. ");
            Console.WriteLine($"Введите {exitCommand} что бы завершить программу");

            while (isWork)
            {
                Console.Write("Ввод: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    numbers.Add(number);
                }

                else if (userInput == exitCommand)
                {
                    numbers.Clear();
                    isWork = false;
                    Console.Clear();
                }

                else  if (userInput == sumCommand)
                {
                    int nunberSum = numbers.Sum();

                    Console.WriteLine($"Сумма: {nunberSum}");
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }

        }
    }
}
