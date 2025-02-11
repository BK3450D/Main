using System;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];

            string exitCommand = "exit";
            string sumCommand = "sum";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите {sumCommand} что бы сложить числа. ");
                Console.WriteLine($"Введите {exitCommand} что бы завершить программу");
                Console.Write("Ввод: ");

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }

                string userInput = Console.ReadLine();

                if (userInput == sumCommand)
                {
                    int nunberSum = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        nunberSum += numbers[i];

                    }
                    Console.WriteLine($"Сумма: {nunberSum}");

                    Array.Clear(numbers, 0, numbers.Length);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (userInput == exitCommand)
                {
                    Console.Clear();
                    isWork = false;
                }
                else
                {
                    int[] tempNumbers = new int[numbers.Length + 1];
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }
                    tempNumbers[tempNumbers.Length - 1] = Convert.ToInt32(userInput);
                    numbers = tempNumbers;

                    Console.Clear();
                }
            }
        }
    }
}


