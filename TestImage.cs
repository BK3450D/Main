using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество картинок? ");
            int imagesAmount = Convert.ToInt32 (Console.ReadLine());

            Console.Write("Количество картинок в строке? ");
            int picturesInRow = Convert.ToInt32(Console.ReadLine());
            
            int  fullRows;
            int imageOwerCup;

            fullRows =  imagesAmount / picturesInRow;
            imagesInLastRow = image % picturesInRow;

            Console.WriteLine("Строк картинок: " +  fullRows);
            Console.WriteLine("Картинок не вместилось: " + imagesInLastRow);
        }
    }
}





