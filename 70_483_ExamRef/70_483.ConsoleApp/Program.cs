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

                    Console.WriteLine("finishing processing");
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
