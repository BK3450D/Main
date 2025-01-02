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
            int image = Convert.ToInt32 (Console.ReadLine());

            Console.Write("Количество рядов картинок? ");
            int line = Convert.ToInt32(Console.ReadLine());

            int imageInLine;
            int imageOwerCup;

            imageInLine =  image / line;
            imageOwerCup = image % line;

            Console.WriteLine("Строк картинок: " + imageInLine);
            Console.WriteLine("Картинок не вместилось: " + imageOwerCup);






            


































        }

    }
}




