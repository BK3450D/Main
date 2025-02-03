using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int line = 10;
            int rows = 10;

            int maxRandom = 10;
            int minRandom = 1;

            int[,] array = new int[line, rows];

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minRandom, maxRandom +1);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            int maxNumber = array[0, 0];

            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (array[i, j] > maxNumber)
                    {
                        maxNumber = array[i, j];
                    }
                }
            }
            
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (array[i, j] == maxNumber)
                    {
                        array[i, j] = 0;
                    }
                }
            }
            
            Console.WriteLine(" ");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                    
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
            Console.WriteLine($"Максимальное значение матрицы: {maxNumber}");
        }
    }
}
