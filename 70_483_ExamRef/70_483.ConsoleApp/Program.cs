using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {

            //Parallel.Invoke(() => Task1(), () => Task2());
            //Console.WriteLine("finishing processing");
            //Console.ReadKey();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }


        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Action Delegate ");
            Console.WriteLine("2) Aggregate Exceptions ");
            

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    string location = "Chicago";
                    Alarm alarm = new Alarm();
                    alarm.OnAlarmRaised += Methods.AlarmListener1;
                  //   alarm.OnAlarmRaised += Methods.AlarmListener2;
                    alarm.RaiseAlarm(location);


                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;
               
                case "2":
                    //exceptions
                    string location2 = "Chicago";
                    Alarm alarm2 = new Alarm();
                    alarm2.OnAlarmRaised += Methods.AlarmListener1Exception;
                    alarm2.OnAlarmRaised += Methods.AlarmListener2Exception;
                   // alarm2.RaiseAlarmExceptions(location2);

                    try
                    {
                        alarm2.RaiseAlarmExceptions("Kitchen");
                    }
                    catch (AggregateException agg)
                    {
                        foreach (Exception exception in agg.InnerExceptions)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }

                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

              
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

   



    }
}
