using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLock
{
    /// <summary>
    /// we need to lock the value of count, so that multiple different threads cannot read and write to
    /// it at the same time.With the addition of a lock and a key, we can prevent the threads from accessing the data 
    /// simultaneously.
    /// </summary>
    class Program
    {
        static int counter { get; set; }
        static readonly object key = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread thread = new Thread(countingNumbers);
                thread.Start();
                Thread.Sleep(500);
            }

            Console.WriteLine("without lock");
            for(int i = 0; i<10; i++)
            {
                ThreadStart threadStart = new ThreadStart(tickingMethod);
                new Thread(threadStart).Start();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            

            

            Console.ReadKey();
        }

        private static void tickingMethod()
        {
            Thread.Sleep(100);
            Console.WriteLine(Environment.TickCount);

            Console.WriteLine("with locking");
            lock(key){
                Thread.Sleep(100);
                Console.WriteLine(Environment.TickCount);
            }

        }

        private static int countingNumbers(object Number)
        {
            while(true)
            {
                lock (key)
                {
                    int temp = counter;
                    Console.WriteLine(" Number of thread : " + Number + " is yet to read");
                    Thread.Sleep(1000);
                    counter = temp + 1;
                    Console.WriteLine(" incrementing the counter ... Thread Num : " + Number + " count: " + counter); 
                }
                Thread.Sleep(1000);
                /* before locking this is output *
                 * Number of thread : 0 is yet to read
                     Number of thread : 1 is yet to read
                     Number of thread : 2 is yet to read
                     incrementing the counter ... Thread Num : 0 count: 1
                     incrementing the counter ... Thread Num : 1 count: 1
                     incrementing the counter ... Thread Num : 2 count: 1
                     Number of thread : 0 is yet to read
                     Number of thread : 1 is yet to read
                     Number of thread : 2 is yet to read
                     incrementing the counter ... Thread Num : 0 count: 2
                     incrementing the counter ... Thread Num : 1 count: 2
                     incrementing the counter ... Thread Num : 2 count: 2
                     Number of thread : 0 is yet to read
                */


                /* After locking with key and object
                 * 
                     Number of thread : 0 is yet to read
                     incrementing the counter ... Thread Num : 0 count: 1
                     Number of thread : 1 is yet to read
                     incrementing the counter ... Thread Num : 1 count: 2
                     Number of thread : 2 is yet to read
                     incrementing the counter ... Thread Num : 2 count: 3
                     Number of thread : 0 is yet to read
                     incrementing the counter ... Thread Num : 0 count: 4
                     Number of thread : 1 is yet to read
                     incrementing the counter ... Thread Num : 1 count: 5
                     Number of thread : 2 is yet to read
                     incrementing the counter ... Thread Num : 2 count: 6
                     Number of thread : 0 is yet to read
                     incrementing the counter ... Thread Num : 0 count: 7
                     Number of thread : 1 is yet to read
                     incrementing the counter ... Thread Num : 1 count: 8
                     Number of thread : 2 is yet to read
                     incrementing the counter ... Thread Num : 2 count: 9

                 */

                return 1;
            }
        }
    }
}
