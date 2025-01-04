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
            int hour;
            int minute;
            int people;
            int reception = 10;
            
            Console.Write("Введите кол - во пациентов: ");
            people = Convert.ToInt32(Console.ReadLine());
            minute = people * reception;
            hour = minute / 60;
            minute -= hour * 60;
            Console.WriteLine($"Вы должны отстоять в очереди {hour} часа и {minute} минут");
        }
    }
}
