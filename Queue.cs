using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalAmountMoney = 0;           
            int numbersInQueue = 0;

            int queueLenght = GenerationQueue();

            Queue<int> purchaseAmount = new Queue<int>(queueLenght);

            GenerationPrice(purchaseAmount, queueLenght);

            while (purchaseAmount.Count > 0)
            {
                Console.WriteLine($"Длина очереди: {queueLenght--}");
                Console.WriteLine($"Количество денег: {totalAmountMoney}");

                totalAmountMoney += purchaseAmount.Peek();

                Console.WriteLine($"Покупатель {++numbersInQueue} купил товар на {purchaseAmount.Dequeue()}$");

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void GenerationPrice(Queue<int> purchaseAmount, int queueLenght)
        {
            int mimPrice = 1;
            int maxPrice = 100;

            Random randPrice = new Random();

            for (int i = 0; i < queueLenght; i++)
            {
                int price = randPrice.Next(mimPrice, maxPrice);

                purchaseAmount.Enqueue(price);
            }
        }

        private static int GenerationQueue()
        {
            int mimLenghtQueue = 3;
            int maxLenghtQueue = 20;

            Random randQueue = new Random();

            int queue = randQueue.Next(mimLenghtQueue, maxLenghtQueue);


            return queue;
        }
    }
}
