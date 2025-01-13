using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string userName;
            string middleLine;

            char userSymbol;

            Console.Write("Введите имя: ");
            userName = Console.ReadLine();

            Console.Write("Введите символ: ");
            userSymbol = Convert.ToChar(Console.ReadLine());
                        
            middleLine = userSymbol + userName + userSymbol;

            string frame = Convert.ToString(userSymbol);

            for (int frameHeight = 1; frameHeight < middleLine.Length; frameHeight++)
            {
                frame += userSymbol;
            }

            Console.WriteLine(frame);
            Console.WriteLine(middleLine);
            Console.WriteLine(frame);
        }
    }
}
