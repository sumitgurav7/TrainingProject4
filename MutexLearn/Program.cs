using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexLearn
{
    class Program
    {
        private static Mutex mutexObj = new Mutex();
        private const int resourceIteration = 2;
        private const int numberOfThread = 5;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartAllThreads();
            Console.ReadKey();
        }

        private void StartAllThreads()
        {
            for(int i = 0; i<numberOfThread; i++)
            {
                ThreadStart threadStart = new ThreadStart(RunThisMethod);
                Thread thread = new Thread(threadStart);
                thread.Name = String.Format("Thread : " + i);
                thread.Start();
            }
        }

        private static void RunThisMethod()
        {
            for(int i = 0; i<resourceIteration; i++)
            {
                ResourcePlanning();
            }
        }

        private static void ResourcePlanning()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Is now will try to take ownership");
            if (mutexObj.WaitOne(1500))
            {
                Console.WriteLine("This is protected area and " + Thread.CurrentThread.Name + " has entered in it ");
                Thread.Sleep(2000);
                Console.WriteLine(Thread.CurrentThread.Name + " Leaving Critical area");
                mutexObj.ReleaseMutex();
                Console.WriteLine(Thread.CurrentThread.Name + " Released Mutex");
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Couldnt get ownership and timed out");
            }
        }
    }
}
