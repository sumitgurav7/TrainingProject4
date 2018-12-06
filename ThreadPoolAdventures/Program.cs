using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolAdventures
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(DisplayThreadInfo);

            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("main thread details");
            Console.WriteLine("Current Thread Id" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Current Is BackGround" + Thread.CurrentThread.IsBackground);
            Console.WriteLine("Current IsThreadPool" + Thread.CurrentThread.IsThreadPoolThread);
            
            Console.WriteLine("main Thread Exiting");
            Console.ReadKey();
        }

        private static void DisplayThreadInfo(object state)
        {
            Console.WriteLine("Sub thread details");
            Console.WriteLine("Current Thread Id" + Thread.CurrentThread.ManagedThreadId);
           // Thread.Sleep(2000);
            Console.WriteLine("Current Is BackGround" + Thread.CurrentThread.IsBackground);
            Console.WriteLine("Current IsThreadPool" + Thread.CurrentThread.IsThreadPoolThread);

        }
    }
}
