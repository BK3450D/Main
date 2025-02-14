using System;

namespace numberSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = new int[10];

            int maxRandomNumber = 10;
            int minRandomNumber = 1;

            Random random = new Random();

            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = random.Next(minRandomNumber, maxRandomNumber + 1);

                Console.Write(numbersArray[i] + " | ");

            }

            Console.WriteLine("Изначальный масcив");

            for (int i = 0; i < numbersArray.Length; i++)
            {
                for (int j = 0; j < numbersArray.Length - 1; j++)
                {
                    if (numbersArray[j] > numbersArray[j + 1])
                    {
                        int temp = numbersArray[j];
                        numbersArray[j] = numbersArray[j + 1];
                        numbersArray[j + 1] = temp;
                    }
                }
            }


            foreach (var item in numbersArray)
            {
                Console.Write(item + " | ");
            }
            Console.WriteLine("Отсортированный массив");
        }
    }
}
