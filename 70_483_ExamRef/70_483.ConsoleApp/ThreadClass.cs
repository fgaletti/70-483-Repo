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
            Thread.Sleep(3000);
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        public static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data  )   ;
            Thread.Sleep(2000);
        }
        
        // data storage and ThreadLocal
        public static ThreadLocal<Random> randomGenerator = new ThreadLocal<Random>(() =>
        {
            return new Random(2);
        });

        // thread context
        public static void DisplayThread(Thread t)
        {
            Console.WriteLine("Name: {0}" , t.Name);
            Console.WriteLine("Culture: {0}", t.CurrentCulture);
            Console.WriteLine("Priority: {0}", t.Priority);
            Console.WriteLine("Context: {0}", t.ExecutionContext);
            Console.WriteLine("IsBackgroung: {0}", t.IsBackground);
            Console.WriteLine("IsPool?: {0}", t.IsThreadPoolThread);
        }

        // thread POOL
        public static void DoWork(Object state)
        {
            Console.WriteLine("Doing Work: {0}", state);
            Thread.Sleep(500);
            Console.WriteLine("Work finished: {0}", state);
        }
    }
}
