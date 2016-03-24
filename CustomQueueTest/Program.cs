using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomQueue;

namespace CustomQueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] arr = new object[] { "123", "123213", 1232, 0.3 };
            CustomQueue<object> queue = new CustomQueue<object>(arr);
            queue.Enqueue("My name is Nataly");
            queue.Enqueue(312);
            queue.Enqueue(new List<int>());
            queue.Enqueue(new DateTime());
            foreach (var variable in queue)
            {
                Console.WriteLine(variable);
            }
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine('\n');
            foreach (var variable in queue)
            {
                Console.WriteLine(variable);
            }
            Console.ReadLine();
            CustomQueue<int> queue1 = new CustomQueue<int>(12,23,54,23,43);
            foreach (var variable in queue1)
            {
                Console.WriteLine(variable);
            }
            queue1.Dequeue();
            queue1.Dequeue();
            Console.WriteLine('\n');
            foreach (var variable in queue1)
            {
                Console.WriteLine(variable);
            }

            Console.ReadLine();
        }
    }
}
