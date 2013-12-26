using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SemaphoreImpl
{
    class Program
    {
        private Semaphore _semaphore;

        private void Test()
        {
            _semaphore = new Semaphore(3, 3);

            for (int i = 1; i <= 5; i++)
            {
                var thread = new Thread(Run);
                thread.Start(i);
            }
        }

        private void Run(object obj)
        {
            _semaphore.WaitOne();
            var id = (int) obj;

            Console.WriteLine("Thread entered {0}", id);

            Thread.Sleep(1000*id);
            _semaphore.Release();

            Console.WriteLine("Thread released {0}", id);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Test();

            Console.ReadLine();
        }
    }
}
