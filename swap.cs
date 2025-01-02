using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество золота: ");
            int gold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество алмазов: ");
            int diamond = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"У вас  {gold} золота и {diamond} алмазов");
            Console.WriteLine("могу обменять на ");
            (gold, diamond) = (diamond, gold);
            Console.WriteLine("Золота: " + gold);
            Console.WriteLine("Злмазов: " + diamond);
        }
    }
}

