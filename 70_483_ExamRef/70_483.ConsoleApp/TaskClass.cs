using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
    public class TaskClass
    {
        public static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }

        public static void DoWork(int i)
        {
            Console.WriteLine("Task {0} starting", i);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} finishing", i);
        }

        // continuation 

        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        // error
        public static void HelloTaskFailure()
        {
            Thread.Sleep(1000);
            Console.WriteLine("WorldTaskFailure");
            throw new Exception();  // 
        }
        public static void ExceptionTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Exceptionn");
        }
        // end continuation 

        // attached
        public static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(500);
            Console.WriteLine("Child {0} finished", state);
        }
    }
}
