using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Signaling
{
    class Program
    {
        private ManualResetEvent _mre;
        private AutoResetEvent _are;

        private void TestMRE()
        {
            _mre = new ManualResetEvent(false);
          
            var thread = new Thread(Proc1);
            thread.Start();

            for (;;)
            {
                Thread.Sleep(1000);
                _mre.Set();
            }
        }

        private void Proc1()
        {
            for (;;)
            {
                Console.WriteLine("Start");

                _mre.WaitOne();

                Console.WriteLine("End");

                // Sets the state of the event to nonsignaled, causing threads to block. 
                _mre.Reset();
            }
        }

        private void TestARE()
        {
            _are = new AutoResetEvent(false);

            var thread = new Thread(Proc2);
            thread.Start();

            for (;;)
            {
                Thread.Sleep(1000);
                _are.Set();
            }
        }

        private void Proc2()
        {
            for (;;)
            {
                Console.WriteLine("Start");

                _are.WaitOne();

                Console.WriteLine("End");
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.TestMRE();

            Console.Read();
        }
    }
}
