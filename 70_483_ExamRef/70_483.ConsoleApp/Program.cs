using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;
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
            Console.WriteLine("1)  Delete Rows list");
            Console.WriteLine("2)  Dictionary");
            Console.WriteLine("3)  DatAjSON"); // Console.WriteLine("2)  Dictionary");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":
                    List<int> listInts = new List<int>();
                    listInts.Add(1);
                    listInts.Add(2);
                    listInts.Add(3);
                    listInts.Add(4);

                    // remove
                    for (int i = 0; i < listInts.Count ; i++)
                    {
                        listInts.RemoveAt(0);
                    }
               

                    Console.WriteLine("finishing processing Remove list");
                    Console.ReadKey();
                    return true;
                case "2":
                    //dictionary
                    Dictionary<int, string> dict = new Dictionary<int, string>();
                    dict.Add(0, "cero");
                    dict.Add(1, "uno");
                    

                    ConcurrentDictionary<int, string> condict = new ConcurrentDictionary<int, string>();

                    condict.TryAdd(0, "cero");
                    condict.TryAdd(1, "uno");

                    string valorEliminar;
                    condict.TryRemove(1, out valorEliminar);


                    Console.WriteLine("finishing processing Remove list");
                    Console.ReadKey();
                    return true;

                case "2":
                    //dictionary
                    var ser = new DataContractJsonSerializer(typeof(Dog));


                    Console.WriteLine("finishing processing Remove list");
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
