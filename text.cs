using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lineOfTexy = "Здравствуйте, мне кажется или это слишком простое задание.";

            string[] subs = lineOfTexy.Split(' ');

            foreach (var sub in subs)
            {
                Console.WriteLine($" {sub}");
            }
        }
    }
}
