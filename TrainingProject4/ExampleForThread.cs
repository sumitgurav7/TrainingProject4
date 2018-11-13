using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrainingProject4
{
    class ExampleForThread
    {
        public static void StartThisProcess()
        {
            for(int i =0; i<10; i++)
            {
                Console.WriteLine("Inside Thread Example " + i);
                Thread.Sleep(0);
            }
        }
    }
}
