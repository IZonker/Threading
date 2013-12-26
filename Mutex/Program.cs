using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexImpl
{
    class Program
    {
        private Mutex _mutex;

        private void Test()
        {
            _mutex = new Mutex();

            for (int i = 1; i <= 5; i++)
            {
                var thread = new Thread(Run);
                thread.Start(i);
            }
        }

        private void Run(object obj)
        {
            _mutex.WaitOne();
            var id = (int)obj;

            Console.WriteLine("Thread entered {0}", id);

            Thread.Sleep(1000);
            _mutex.ReleaseMutex();

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
