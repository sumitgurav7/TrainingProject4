using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrainingProject4
{
    /// <summary>
    /// this is for threading Poc
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("this is main program");

            Thread t = new Thread(new ThreadStart(ExampleForThread.StartThisProcess));

            t.Start();

            for(int i =0; i<6; i++)
            {
                Console.WriteLine("this is main thread after starting t thread");
                Thread.Sleep(0);
            }
            t.Join();
            Console.ReadKey();
        }
    }
}
