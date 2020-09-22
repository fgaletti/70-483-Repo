using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
     public  static class ParallelEntity
    {
        public static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }
        public static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }

        public static void WorkOnItem(object item)
        {
            Console.WriteLine("starting working on :" + item);
           // Thread.Sleep(1000);
            Console.WriteLine("finishing working on :" + item);
        }

        public class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }
    }
}
