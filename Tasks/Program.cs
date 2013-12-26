using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => Console.WriteLine("Hello"));
         
            DisplayPrimesCount();
            Console.WriteLine("Called");
           // Console.Read();
        }

        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
            ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        static async void DisplayPrimesCount()
        {
            int result = await GetPrimesCountAsync(2, 1000000);
            Console.WriteLine(result);
        }
    
    }
}
