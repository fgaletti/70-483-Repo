using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Console.WriteLine("3) Create Delgates");
            Console.WriteLine("4 ) Lambda");
            Console.WriteLine("5 ) Func");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    string location = "Chicago";
                    Alarm alarm = new Alarm();
                    alarm.OnAlarmRaised += AlarmListener1;
                  //   alarm.OnAlarmRaised += Methods.AlarmListener2;
                    alarm.RaiseAlarm(location);


                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;
               
                case "2":
                    //exceptions
                    string location2 = "Chicago";
                    Alarm alarm2 = new Alarm();
                    alarm2.OnAlarmRaised += AlarmListener1Exception;
                    alarm2.OnAlarmRaised += AlarmListener2Exception;
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

                case "3":
                    //create delegates

                    var ope = new IntOperation(Add);
                    ope(2, 3);

                    var del1 = new DelConcactString(ConcactString);
                    string returnDel = del1("kk", "ss");

                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "4":
                    //lambda

                    SetLocalInt();

                    // no lambda
                    GetValue getValueFunction = new GetValue(GetLocalNoLambda);
                    int returnInt = getValueFunction();

                    // lambda

                    DelConcactString del2;
                    

                    del2 = (a,b ) =>  { return a + b; };
                    string returnDel2 = del2("Str11", "Streee222");
                    
                      
                    Console.WriteLine("Finishing Lambda");
                    Console.ReadKey();
                    return true;

                case "5":
                    //Func

                    Func<string, string, string, string> delFunc = (a,b, c) => { return a + b + c; });


                    Console.WriteLine("Finishing Lambda");
                    Console.ReadKey();
                    return true;

                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

        // 5 --- funcv
        Func<int> numberIn;

        static double ReturnSquareFunc(int number)
        {
            return Math.Sqrt(number);
        }
        // ------------

        // 4 
        delegate int GetValue();
        static GetValue getLocalInt;


        static void SetLocalInt()
        {
            // Local variable set to 99
            int localInt = 99;
            // Set delegate getLocalInt to a lambda expression that
            // returns the value of localInt
            //getLocalInt = () => Console.WriteLine("Inside Lambda");  localInt;
            getLocalInt = () => { Console.WriteLine("Inside Lambda"); return localInt; };

        }

        static int GetLocalNoLambda()
        {
            Console.WriteLine("GetLocalNoLambda"   );
            return 109;
        }
        // --- end 4

        // Class Alarm

        public class AlarmEventArgs : EventArgs
        {
            public string Location { get; set; }
            public AlarmEventArgs(string location)
            {
                Location = location;
            }
        }


        public class Alarm
        {
            // event = secure

            // delegate
            // 1 . simple  public Action OnAlarmRaised { get; set; }
            // 2 . eventHandle : public event EventHandler OnAlarmRaised = delegate { };
            // Delegate for the alarm event
            public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };
           

            // called toi raise an alart
            public void RaiseAlarm(string location)

            {
                // only raise y someone s subscribed
                if (OnAlarmRaised != null)
                {
                    // 2. 
                    // 2.  OnAlarmRaised(this, EventArgs.Empty ); 
                    // 3 pass EventArgs
                    OnAlarmRaised(this, new AlarmEventArgs(location));

                }
            }

            public void RaiseAlarmExceptions(string location)

            {

                List<Exception> exceptionList = new List<Exception>();

                foreach (Delegate handler in OnAlarmRaised.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(this, new AlarmEventArgs(location));
                    }
                    catch (TargetInvocationException e)
                    {
                        exceptionList.Add(e.InnerException);

                    }
                }

                if (exceptionList.Count > 0)
                    throw new AggregateException(exceptionList);
            }
        }

        //Methods

        public delegate int IntOperation(int a, int b);

        public static int Add(int a, int b)
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
        public static void AlarmListener1(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 called");
            Console.WriteLine("Alarm in {0}", args.Location);
        }

        public static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }

        public static void AlarmListener1Exception(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 called");
            Console.WriteLine("Alarm in {0}", args.Location);
            throw new Exception("Bang");
        }

        public static void AlarmListener2Exception(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 2 called");
            throw new Exception("boom");
        }

        // custgom delegate
        public delegate string  DelConcactString(string str1, string str2);

        public static string ConcactString(string str1, string str2)
        {
            return str1 + str2;
        }

    }
}
