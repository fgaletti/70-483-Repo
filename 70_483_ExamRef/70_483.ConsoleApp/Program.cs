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
            Console.WriteLine("1) Parallel ");
            Console.WriteLine("2) Parallel foreach");
            Console.WriteLine("3) Parallel for");
            Console.WriteLine("4) Parallel LINQ");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":
                    Parallel.Invoke(() => ParallelEntity.Task1(), () => ParallelEntity.Task2());
                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;
               
                case "2":
                    var items = Enumerable.Range(0, 500);
                    Parallel.ForEach(items, item =>
                    {
                        ParallelEntity.WorkOnItem(item);
                    });
                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "3":

                    //FOR
                    var items2 = Enumerable.Range(0, 50).ToArray();
                    Parallel.For(0, items2.Length, i =>
                    {
                        ParallelEntity.WorkOnItem(items2[i]);
                    });

                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "4":
                    ParallelEntity.Person[] people = new ParallelEntity.Person[]
                    {
                     new ParallelEntity.Person { Name="Alan", City="Hull"},
                      new ParallelEntity.Person { Name="Berly", City="Seattle"},
                       new ParallelEntity.Person { Name="Charles", City="London"},
                     new ParallelEntity.Person { Name="David", City="Seattle"},
                      new ParallelEntity.Person { Name="Eddy", City="Paris"},
                       new ParallelEntity.Person { Name="Fred", City="BErlin"},
                        new ParallelEntity.Person { Name="Grodon", City="Hulll"},
                         new ParallelEntity.Person { Name="Henry", City="Seatle"},
                          new ParallelEntity.Person { Name="Isaac", City="London"}
                    };

                    var result = from person in people.AsParallel()
                                 where person.City == "Seattle"
                                 select person;

                    foreach (var person in result)
                    {
                        Console.WriteLine(person.Name);
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

        //    static void Task1()
        //{
        //    Console.WriteLine("Task 1 starting");
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Task 1 ending");
        //}
        //static void Task2()
        //{
        //    Console.WriteLine("Task 2 starting");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Task 2 ending");
        //}



    }
}
