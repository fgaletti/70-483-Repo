//#define DIAGNOSTICS

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("1) Assembly Class  ");
            Console.WriteLine("2) Use Dll  ");
            Console.WriteLine("3) Diagnostic  ");
            Console.WriteLine("4) Conditional Attribute  ");
            Console.WriteLine("5) Warning  ");
            Console.WriteLine("6) error Directive  ");
            Console.WriteLine("7) Identity error Position with #line  ");
            Console.WriteLine("8) Hide code using #line  ");
            Console.WriteLine("9) debuggerstepthrough  ");

            Console.WriteLine("10) logging Debug   ");
            Console.WriteLine("11) logging Trace   ");

            Console.WriteLine("12) Assert   ");
            Console.WriteLine("13) TraceListert   "); //285
            Console.WriteLine("14) DelimitedTraceLsitener   "); //285
            Console.WriteLine("15) TraceSource   "); //285
            Console.WriteLine("16) TraceSwitch   "); //287
            Console.WriteLine("17) SourceSwitch   "); //287

            Console.WriteLine("18) Tracing app.config   "); //287

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":

                    Assembly a = typeof(Program).Assembly;
                    Console.WriteLine(a.FullName);
                    AssemblyName name = a.GetName();
                    Console.WriteLine(name.Version.Major);
                    Console.WriteLine(name.Version.MajorRevision);
                    Console.WriteLine(name.Version.Minor);
                    Console.WriteLine(name.Version.MinorRevision);

                    Console.WriteLine("finishing assembly");
                    Console.ReadKey();
                    return true;
                case "2":
                    // test dll version
                    DllGac.ClassGac clGac = new DllGac.ClassGac();
                    Console.WriteLine(clGac.getValueFromGac());

                    Console.WriteLine("finishing gac");
                    Console.ReadKey();
                    return true;
                case "3":
                    // diagnostic

                    Console.WriteLine("Pint ..");

#if DIAGNOSTICS
                    Console.WriteLine("Printing DIAGNOSTICS");
#endif

#if DEBUG
                    Console.WriteLine("Debug version");
#endif
#if TERSE
                Console.WriteLine("TERSEEn");
#endif
#if NORMAL
                Console.WriteLine("NORMAL");
#endif
#if CHATTY
                Console.WriteLine("CHATTY");
#endif

                    Console.WriteLine("finishing diagnostic");
                    Console.ReadKey();
                    return true;
                case "4":
                    // conditional
                    Display("Message display");

                    string callOld = OldMethod();

                    Console.WriteLine("finishing conditional attribute");
                    Console.ReadKey();
                    return true;
                case "5":
                    // warning
#warning this version of library is no longer maintained

                    Console.WriteLine("finishing gac");
                    Console.ReadKey();
                    return true;
                case "6":
                    // error

#if DIAGNOSTICS && RELEASE
#error cannot run with boht diagnostic and RELEASE enabled
#endif

                    Console.WriteLine("finishing gac");
                    Console.ReadKey();
                    return true;
                case "7":
                    // #line
                    try
                    {
                        Exploded();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }

                    Console.WriteLine("finishing gac");
                    Console.ReadKey();
                    return true;
                case "8":
                    // hide

                    Console.WriteLine("Before Hide");
#line hidden
                    Console.WriteLine("hidden");
#line default

                    Console.WriteLine("finishing gac");
                    Console.ReadKey();
                    return true;
                case "9":
                    // debuggerstepthrough
                    Console.WriteLine("Before update");
                    update(); // call update , does not debug
                    UpdateInside(); // normal
                    Console.WriteLine("After..");

                    Console.WriteLine("finishing gac");
                    Console.ReadKey();
                    return true;
                case "10":
                    // logging debug

                    Debug.WriteLine("Starting ");
                    Debug.Indent();
                    Debug.WriteLine("Inside");
                    Debug.Unindent();
                    Debug.WriteLine("Outside");
                    string customer = "Rob";
                    Debug.WriteLineIf(string.IsNullOrEmpty(customer), "Csutomer empty");

                    Console.WriteLine("finishing logging debug");
                    Console.ReadKey();
                    return true;
                case "11":
                    // trace 

                    Trace.WriteLine("Starting the program");
                    Trace.TraceInformation("Starting the program");
                    Trace.TraceWarning("thuis a warning");
                    Trace.TraceError("this is an error");

                    string customer11 = "Rob";
                    Trace.WriteLineIf(string.IsNullOrEmpty(customer11), "Csutomer empty TRACE");

                    Console.WriteLine("finishing logging TRACE");
                    Console.ReadKey();
                    return true;

                case "12":
                    // assert 

                    string customer12 = "Rob";
                    Debug.Assert(!string.IsNullOrEmpty(customer12));

                     customer12 = "";
                    Debug.Assert(!string.IsNullOrEmpty(customer12));

                    Console.WriteLine("finishing assert");
                    Console.ReadKey();
                    return true;

                case "13":
                    // assert 

                    TraceListener consoleLister = new ConsoleTraceListener();
                    Trace.Listeners.Add(consoleLister);

                    Trace.TraceInformation("This is information message");
                    Trace.TraceWarning("Warning");
                    Trace.TraceError("Error");

                    Console.WriteLine("finishing assert");
                    Console.ReadKey();
                    return true;
                case "14":
                    // delimited 
                    Trace.Listeners.Add(new TextWriterTraceListener("TextWriterOutput.log", "myListener"));
                    Trace.TraceInformation("Test message.");
                    Trace.TraceInformation("Line2 message.");
                    Trace.TraceWarning("Warning message delimited");
                    Trace.TraceError("Error delimm");
                    // You must close or flush the trace to empty the output buffer.
                    Trace.Flush();
                                        

                    Console.WriteLine("finishing delimited");
                    Console.ReadKey();
                    return true;
                case "15":
                    // tracesource 

                    TraceSource trace = new TraceSource("Tracer40", SourceLevels.All);
                    trace.TraceEvent(TraceEventType.Start, 10000);
                    trace.TraceEvent(TraceEventType.Warning, 10001);
                    trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
                    trace.TraceData(TraceEventType.Information, 10003, new object[] { "Note1", "Message" });

                    trace.Flush();
                    trace.Close();

                    Console.WriteLine("finishing delimited");
                    Console.ReadKey();
                    return true;
                case "16":
                    // traceswtich 

                    TraceSwitch control = new TraceSwitch("Control", "Control the trace output");
                    control.Level = TraceLevel.Warning;

                    //if(control.TraceError)
                    //{
                    //    Console.WriteLine("Error has ocurrer");
                    //}

                    Trace.WriteLineIf(control.TraceWarning, "A warning message 16");

                    Console.WriteLine("finishing delimited");
                    Console.ReadKey();
                    return true;

                case "17":
                    // sourceswitch 
                    TraceSource trace17 = new TraceSource("Tracer17", SourceLevels.All);
                    trace17.TraceEvent(TraceEventType.Start, 10000,"luka");

                    SourceSwitch control17 = new SourceSwitch("control", "Controls the tracing");
                    control17.Level = SourceLevels.Information; // levels
                    trace17.Switch = control17;

                    trace17.TraceEvent(TraceEventType.Start, 10000);
                    trace17.TraceEvent(TraceEventType.Warning, 10001);
                    trace17.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program 17");
                    trace17.TraceData(TraceEventType.Information, 10003, new object[] { "Note17", "Message 17" });

                    trace17.Flush();
                    trace17.Close();

                    Console.WriteLine("finishing delimited");
                    Console.ReadKey();
                    return true;

                case "18":
                    // sourceswitch 
                    TraceSource trace18 = new TraceSource("configControl");

                    trace18.TraceEvent(TraceEventType.Start, 10000);
                    trace18.TraceEvent(TraceEventType.Warning, 10001);
                    trace18.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program 18, Config");
                    trace18.TraceData(TraceEventType.Information, 10003, new object[] { "Note18", "Message 18" });

                    trace18.Flush();
                    trace18.Close();

                    Console.WriteLine("finishing delimited");
                    Console.ReadKey();
                    return true;
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

        // Conditional 273
        [Conditional("DEBUG")]
        static void Display(string message)
        {
            Console.WriteLine(message);
        }

        // mark obsolete
        [Obsolete("This is old method , call new one")]
        public static string OldMethod()
        {
            return "Old";
        }

        // pragma warning   274
        // disable warning CS1998

#pragma warning disable
        public static async Task<int> returnTask()
        {
            return 99;
        }
#pragma warning restore
        // warning  CS1998: method lacks await
        public static async Task<int> returnTaskWithWarning()
        {
            return 77;
        }

        // #line  
        // sets the line number to 1
        static void Exploded()
        {
#line 1 "kapow"
            throw new Exception("bang");
#line default
        }

        //debuggerstepthrowu  276

        [DebuggerStepThrough]
        public static void update()
        {
            Console.WriteLine("Update..");
        }

        //normal
        public static void UpdateInside()
        {
            Console.WriteLine("Inside ..");
        }
    }
}
