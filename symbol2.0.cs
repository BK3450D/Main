using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symbol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int frameHeight = 1;
            int frameWidth;

            string userName;
 
            string middleLine;

            char userSymbol;

            Console.Write("Введите имя: ");
            userName = Console.ReadLine();

            Console.Write("Введите символ: ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            
            middleLine = userSymbol + userName + userSymbol;

            frameWidth = middleLine.Length;

            for (int i = 0; i < frameWidth; i++)
            {
                Console.Write(userSymbol);
                Console.WriteLine(i);
            }

            Console.WriteLine();

            for (int i = 0; i < frameHeight; i++)
            {
                Console.Write(middleLine);
                Console.WriteLine();
            }

            for (int i = 0; i < frameWidth; i++)
            {
                Console.Write(userSymbol);
            }

            Console.WriteLine();

        }
    }
}
