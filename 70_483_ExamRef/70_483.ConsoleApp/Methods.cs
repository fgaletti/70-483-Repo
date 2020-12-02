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
//        public static void AlarmListener1()
       public static void AlarmListener1(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 called");
            Console.WriteLine("Alarm in {0}", args.Location);
        }

        public static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }
    }
}
