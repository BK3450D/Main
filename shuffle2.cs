using System;

namespace shafl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = new int[10];

            int minRandomNumbers = 0;
            int maxRandomNumbers = 9;

            Random random = new Random();

            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = random.Next(minRandomNumbers, maxRandomNumbers);
            }

            PrintArray(numbersArray);

            Shuffle(numbersArray);

            Console.WriteLine();

            PrintArray(numbersArray);
        }
        
        static void Shuffle(int[] numbersArray)
        {
           Random random = new Random();

            int minIndex = 0;
            int maxIndex = numbersArray.Length - 1;

            for (int i = 0; i < numbersArray.Length; i++)
            {
                int randomIndex = random.Next(minIndex, maxIndex);

                int tempNumber = numbersArray[randomIndex];

                numbersArray[randomIndex] = numbersArray[i];
                numbersArray[i] = tempNumber;
            }
        }
        
        static void PrintArray(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number);
            }
        }
    }
}

