using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumbers1 = new int[] { 1, 2, 3, 5 };
            int[] arrayNumbers2 = new int[] { 2, 4, 5, 6 };

            List<int> listNambers = new List<int>();

            GetListArray(listNambers, arrayNumbers1);
            Console.WriteLine();
            GetListArray(listNambers, arrayNumbers2);

            listNambers.Sort();

            Console.Write("\nОтсортированный список: ");
            
            foreach (var nambers in listNambers)
            {
                Console.Write(nambers + " | ");
            }           
        }

        static void GetListArray(List<int> listNambers, int[] arrayNambers)
        {
            Console.Write("Массив: ");            
            PrintNumbers(arrayNambers);
            CombineArrays(listNambers, arrayNambers);
        }

        static void CombineArrays(List<int> listNambers, int[] arrayNumbers)
        {
            foreach (int number in arrayNumbers)
            {
                if (listNambers.Contains(number) == false)
                {
                    listNambers.Add(number);
                }       
            }
        }

        static void PrintNumbers(int[] arrayNumbers)
        {
            foreach (var item in arrayNumbers)
            {
                Console.Write($"{item}  | ");
            }
        }
    }
}


