﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
            int amountRepits;
            Console.Write("Введите сообщение:");
            message = Console.ReadLine();
            Console.Write("Введите количество повторений:");
            amountRepits = Convert.ToInt32(Console.ReadLine());

            while (amountRepits -- > 0)
            {
                Console.WriteLine(message);
            }
        }
    }
}
