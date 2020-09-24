using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
     public class ThreadClass
    {
        public static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        public static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data  )   ;
            Thread.Sleep(2000);
        }
    }
}
