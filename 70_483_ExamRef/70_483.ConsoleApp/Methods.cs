using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
    //static methods called from the examples
    class Methods
    {
        // 3. delegates
       public  delegate int IntOperation(int a, int b);

        public static int Add (int a, int b)
        {
            //IntOperation intOP = new IntOperation(Substract);
            //int resta = intOP(2, 4);
            Console.WriteLine("Add called");
            return a + b;


        }
        public static int Substract(int a, int b)
        {
            Console.WriteLine("Substract called");
            return a - b;
        }

        //        public static void AlarmListener1()
        //public static void AlarmListener1(object source, AlarmEventArgs args)
        //{
        //    Console.WriteLine("Alarm listener 1 called");
        //    Console.WriteLine("Alarm in {0}", args.Location);
        //}

        public static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }

        //public static void AlarmListener1Exception(object source, AlarmEventArgs args)
        //{
        //    Console.WriteLine("Alarm listener 1 called");
        //    Console.WriteLine("Alarm in {0}", args.Location);
        //    throw new Exception("Bang");
        //}

        //public static void AlarmListener2Exception(object source, AlarmEventArgs args)
        //{
        //    Console.WriteLine("Alarm listener 2 called");
        //    throw new Exception("boom");
        //}
    }
}
