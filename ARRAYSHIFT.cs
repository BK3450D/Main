using System;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeNumbersArray = 10;

            int[] numbers = new int[sizeNumbersArray];

            int maxRandomNumber = 10;
            int minRandomNumber = 1;

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);

                Console.Write(numbers[i] + " | ");
            }

            Console.Write(" \nВведите количество позиций для сдвига влево: ");
           
            int amoutOfShift = Convert.ToInt32(Console.ReadLine());

            amoutOfShift = amoutOfShift % numbers.Length;

            for (int i = 0; i < amoutOfShift; i++)
            {
                int firstElement = numbers[0];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                numbers[numbers.Length - 1] = firstElement;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " | ");
            }
        }
    }
}