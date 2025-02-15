using System;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeNumbersArray = 10;

            int[] arrayNumbers = new int[sizeNumbersArray];

            int maxRandomNumber = 10;
            int minRandomNumber = 1;

            Random random = new Random();

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                arrayNumbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);

                Console.Write(arrayNumbers[i] + " | ");
            }

            Console.WriteLine("Введите количество позиций для сдвига влево: ");
            Console.SetCursorPosition(86, 0);

            int positions = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < positions; i++)
            {
                int firstElement = arrayNumbers[0];

                for (int j = 0; j < arrayNumbers.Length - 1; j++)
                {
                    arrayNumbers[j] = arrayNumbers[j + 1];
                }
                arrayNumbers[arrayNumbers.Length - 1] = firstElement;
            }

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                Console.Write(arrayNumbers[i] + " | ");
            }
        }
    }
}
