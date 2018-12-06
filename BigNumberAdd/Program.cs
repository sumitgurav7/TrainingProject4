using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumberAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number 1");
            string num1 = Console.ReadLine();
            Console.WriteLine("Enter Number 2");
            string num2 = Console.ReadLine();

            AdditionLogicClass additionLogicClass = new AdditionLogicClass(num1, num2);

            Console.WriteLine(" addition of number " + num1 + " and " + num2 + " is " + additionLogicClass.AddingNumbers());
            Console.ReadKey();
        }
    }
}
