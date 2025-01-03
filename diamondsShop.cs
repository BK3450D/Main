using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            int gold;
            int diamonds;
            int diamondUnitPrice = 10;

            Console.WriteLine("Добро пожаловытьв магазин алмазов! 1 алмаз стоит 10 золота");
            Console.Write("Сколько золота у вас?: ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько алмазов вы хотите купить?: ");
            diamonds = Convert.ToInt32(Console.ReadLine());
            gold -= diamonds * diamondUnitPrice;
            Console.WriteLine($"Вы купили {diamonds} алмазов.");
            Console.WriteLine($"У вас осталосб {gold} золота");
        }
    }
}
