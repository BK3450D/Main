using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeReceptionOnePerson = 10;
            int hourInMinutes = 60;

            Console.Write("Введите кол - во пациентов: ");
            int totalPersonInQueue = Convert.ToInt32(Console.ReadLine());
            int timeInMinuts = totalPersonInQueue * timeReceptionOnePerson;
            int waitingInHours = timeInMinuts / hourInMinutes;
            int waitingInMinutes = timeInMinuts % hourInMinutes;
            Console.WriteLine($"Вы должны отстоять в очереди {waitingInHours} часа и {waitingInMinutes} минут.");
        }
    }
}
