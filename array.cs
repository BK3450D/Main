using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 10;
            int cols = 10;

            int minRandom = 1;
            int maxRandom = 10;

            int[,] array = new int[10, 10];

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minRandom, maxRandom + 1);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            int lineSum = 0;

            for (int i = 0; i < rows; i++)
            {
                lineSum += array[1, i];
     
            }

            int productFirstCols = 1;

            for (int j = 0; j < cols; j++)
            {

                productFirstCols *= array[j, 0];
            }

            Console.WriteLine($"Сумма второй строки: {lineSum}");
            Console.WriteLine($"Произведение первого столбца: {productFirstCols}");
        }
    }
}
