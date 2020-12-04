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
            Console.WriteLine("1) Custom ");
            Console.WriteLine("2) Inner ");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":

                    try
                    {
                        throw new ClassCalcException("Div Zero", ClassCalcException.CalcErrores.DivisionByZero);
                    }
                    catch (ClassCalcException ce) when (ce.Error == ClassCalcException.CalcErrores.DivisionByZero)
                    {
                        Console.WriteLine("Error: {0}", ce.Error);
                    }
                    catch (ClassCalcException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Error);
                    }

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":

                    try
                    {
                        try
                        {
                            Console.Write("Enter an integer: ");
                            string numberText = Console.ReadLine();
                            int result;
                            result = int.Parse(numberText);
                        }
                        catch   (FormatException fx)
                        {
                            throw new Exception("Calculator failure", fx);
                        }
                        catch (Exception ex)

                        {
                            var a = ex.GetType().Name;
                            throw new Exception("Calculator failure", ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException.Message);
                        Console.WriteLine(ex.InnerException.StackTrace);
                    }
            
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

    class ClassCalcException : Exception
    {
        public enum CalcErrores
        {
            InvalidNumberText,
            DivisionByZero
        }
        public CalcErrores Error { get; set; }
        public ClassCalcException (string message, CalcErrores error) :base(message)
        {
            Error = error;
        }

    }
}
