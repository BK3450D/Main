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

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
     
            Console.Write("Ваше имя?: ");
            string name = Console.ReadLine();

            Console.Write("Сколько вам лет?: ");
            int age = Convert.ToInt32 (Console.ReadLine());

            
            Console.Write("Кем вы работаете?:  ");
            string work = (Console.ReadLine());

            Console.WriteLine($"Вас зовут {name}, вам {age},  и вы работаете {work}.");
            
     

        











        }

    }
}




