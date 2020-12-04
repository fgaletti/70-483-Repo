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
            Console.WriteLine("1) Enum  ");
            Console.WriteLine("2) Struct  ");
            Console.WriteLine("3) Static Constructors  ");
            Console.WriteLine("4) Extensions  ");
            Console.WriteLine("5) Index property  ");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(AlineStateNormal.Destroyed); // 1
                    Console.WriteLine(AlienState.Destroyed); // 4

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":

                    Alien a;
                    a.X = 50;
                    a.Y = 60;
                    a.Lives = 4;
                    // initialize all properties
                    Console.WriteLine("a: {0}", a.ToString());

                    Alien[] swarm = new Alien[100];
                    Console.WriteLine("x {0}" , swarm[0].ToString());

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "3":

                    //static alien class
                    // it is called ONCE before the creation of the firts instance of the class
                    AlienClass alien = new AlienClass(); 
                    AlienClass alien2 = new AlienClass(); //should not print 

                    Console.WriteLine("finishing static");
                    Console.ReadKey();
                    return true;

                case "4":

                    //extensions
                    string text = @"a rocker ... ,
                                    line2,
                                     line 33,
                                     line 4";

                    Console.WriteLine(text.LineCount());

                    //case 2
                    int numberToString = 99;
                    Console.WriteLine(numberToString.ToString2()); // extension 

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "5":
                    // Index Property

                    IndexAccess indexClass = new IndexAccess();
                    indexClass[2] = 22; // value passed in [] is not an array 
                    Console.WriteLine(indexClass[2].ToString());

                    // string
                    indexClass["zero"] = 99; // value passed in [] is not an array 
                    Console.WriteLine(indexClass["zero"].ToString());

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

        enum AlineStateNormal
        {
            Sleeping,
            Attacking,
            Destroyed
        }
        enum AlienState :
            byte
        {
            Sleeping =1,
            Attacking =2,
            Destroyed = 4
        };
    }

    struct Alien
    {
        public int X;
        public int Y;
        public int Lives;

        public Alien(int x , int y)
        {
            X = x;
            Y = y;
            Lives = 3;
        }

        public override string ToString()
        {
            return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
        }
    }

    // static constructors
    class AlienClass
    {
        static AlienClass()
        {
            Console.WriteLine("Static Alien constructor");
        }
    }

    //extensions
    public static class MyExtensions
    {
        public static int LineCount(this String str)
        {
            return str.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length; 
        }

        public static string ToString2(this int integer)
        {
            return integer.ToString() + ".000";
        }
    }

    // Index Property
    public class IndexAccess
    {
        private int[] indexArray = new int[100];

        public int this[int i]
        {
            get { return indexArray[i]; }
            set { indexArray[i] = value; }
        }

        public int this[string name] {
            get {
                switch (name)
                {
                    case "zero":
                        return indexArray[0];
                    case "one":
                        return indexArray[1];
                    default:
                        return -1;
                }
            }
            set
            {
                switch (name)
                {
                    case "one":
                        indexArray[1] = value;
                        break;
                    case "zero":
                        indexArray[0] = value;
                        break;
                    default:
                        break;
                } ;
            }
        }
    }
}
