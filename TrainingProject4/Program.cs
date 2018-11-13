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
   partial class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("this is main program");

            Thread t = new Thread(StartThisProcess);
            Thread t1 = new Thread(StartThisProcess);
            Thread t2 = new Thread(StartThisProcess);
            t.Priority = ThreadPriority.Highest;
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            Console.WriteLine(Thread.CurrentThread.Priority);
            t.Start(1);
            t1.Start(2);
            t2.Start(3);
            
            //t.Join();
            //Thread.CurrentThread.Suspend();
            for (int i =0; i<10; i++)
            {
                Console.WriteLine("this is main thread after starting t thread");
                Thread.Sleep(1000);
            }

            //t.Join();

            Console.ReadKey();
        }
        public static void StartThisProcess(object n)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inside Thread Example "+n+" " + i);
                Thread.Sleep(1000);
            }
        }


        public static void StartThisProcess1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inside Thread Example 2 " + i);
                Thread.Sleep(1000);
            }
        }

        public static void StartThisProcess2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inside Thread Example 3 " + i);
                Thread.Sleep(1000);
            }
        }
    }
}
