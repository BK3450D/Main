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
            int frameBorder = 2;
            int frameHeight = 1;
            int frameWidth;

            string userName;

            char userSymbol;

            Console.Write("Введите имя: ");
            userName = Console.ReadLine();

            Console.Write("Введите символ: ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            frameWidth = userName.Length + frameBorder;

            for (int i = 0; i < frameWidth; i++) 
            {
                Console.Write(userSymbol);
            }

            Console.WriteLine();

            for (int i = 0; i < frameHeight; i++)
            {
                Console.Write(userSymbol);
                Console.Write(userName);
                Console.Write(userSymbol);
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
