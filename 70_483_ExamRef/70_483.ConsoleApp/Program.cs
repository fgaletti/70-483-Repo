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
            Console.WriteLine("1) Parallel ");
            Console.WriteLine("2) Parallel foreach");
            Console.WriteLine("3) Parallel for");
            Console.WriteLine("4) Parallel LINQ");

            Console.WriteLine("5) Parallel LINQ -  Informing parallelism");
            Console.WriteLine("6) Parallel LINQ -  Ordered");

            Console.WriteLine("7) Parallel LINQ -  Sequential");

            Console.WriteLine("8) Parallel FORALL");
            Console.WriteLine("9) Exceptions");
            Console.WriteLine("10) Return value from a Task");
            Console.WriteLine("11) WaitAll / WaitAny");
            Console.WriteLine("12)  Continuation Task");
            Console.WriteLine("13)  Continuation Task Exception");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");


            ParallelClass.Person[] people = new ParallelClass.Person[]
                   {
                     new ParallelClass.Person { Name="Alan", City="Hull"},
                      new ParallelClass.Person { Name="Berly", City="Seattle"},
                       new ParallelClass.Person { Name="Charles", City="London"},
                     new ParallelClass.Person { Name="David", City="Seattle"},
                      new ParallelClass.Person { Name="Eddy", City="Paris"},
                       new ParallelClass.Person { Name="Fred", City="Seattle"},
                        new ParallelClass.Person { Name="Grodon", City="Hulll"},
                         new ParallelClass.Person { Name="Henry", City="Seattle"},
                          new ParallelClass.Person { Name="Isaac", City="London"}
                   };


            switch (Console.ReadLine())
            {
                case "1":
                    Parallel.Invoke(() => ParallelClass.Task1(), () => ParallelClass.Task2());
                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":
                    var items = Enumerable.Range(0, 500);
                    Parallel.ForEach(items, item =>
                    {
                        ParallelClass.WorkOnItem(item);
                    });
                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "3":

                    //FOR
                    var items2 = Enumerable.Range(0, 50).ToArray();
                    Parallel.For(0, items2.Length, i =>
                    {
                        ParallelClass.WorkOnItem(items2[i]);
                    });

                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "4":


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

                case "5":
                    // informing parallelism

                    ParallelClass.Person[] people2 = new ParallelClass.Person[]
               {
                     new ParallelClass.Person { Name="Alan", City="Hull"},
                      new ParallelClass.Person { Name="Berly", City="Seattle"},
                       new ParallelClass.Person { Name="Charles", City="London"},
                     new ParallelClass.Person { Name="David", City="Seattle"},
                      new ParallelClass.Person { Name="Eddy", City="Paris"},
                       new ParallelClass.Person { Name="Fred", City="Seattle"},
                        new ParallelClass.Person { Name="Grodon", City="Hulll"},
                         new ParallelClass.Person { Name="Henry", City="Seattle"},
                          new ParallelClass.Person { Name="Isaac", City="London"}
               };

                    var result2 = from person in people2.AsParallel().WithDegreeOfParallelism(4)
                                 .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                  where person.City == "Seattle"
                                  select person;

                    foreach (var person in result2)
                    {
                        Console.WriteLine(person.Name);
                    }
                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "6":
                    // AsOrdered
                    //  // excuted the query in order
                    var result3 = from person in people.AsParallel().AsOrdered()
                                  where person.City == "Seattle"
                                  select person;

                    foreach (var person in result3)
                    {
                        Console.WriteLine(person.Name);
                    }
                    Console.WriteLine("Finishing Ordered");
                    Console.ReadKey();
                    return true;

                case "7":
                    // AsSequential
                    //  return a sorted but not necesary quert in order
                    var result7 = (from person in people.AsParallel()
                                   where person.City == "Seattle"
                                   orderby (person.Name)
                                   select new
                                   {
                                       Name = person.Name
                                   }).AsSequential().Take(2);

                    foreach (var person in result7)
                    {
                        Console.WriteLine(person.Name);
                    }
                    Console.WriteLine("Finishing Sequential");
                    Console.ReadKey();
                    return true;

                case "8":
                    // ForAll
                    // the iteration Take Place in parallel and WILL
                    // START BEFORE the query is COMPLETE
                    var result8 = from person in people.AsParallel()
                                  where person.City == "Seattle"
                                  select person;


                    result8.ForAll(person => Console.WriteLine(person.Name));

                    Console.WriteLine("Finishing ForAll");
                    Console.ReadKey();
                    return true;

                case "9":
                    // EXCEPTIONs in queries

                    ParallelClass.Person[] peopleNull = new ParallelClass.Person[]
                         {
                                     new ParallelClass.Person { Name="Alan", City=null},
                                      new ParallelClass.Person { Name="Berly", City="Seattle"},
                                       new ParallelClass.Person { Name="Charles", City=null},
                                     new ParallelClass.Person { Name="David", City="Seattle"},
                                      new ParallelClass.Person { Name="Eddy", City="Paris"},
                                       new ParallelClass.Person { Name="Fred", City="Seattle"},
                                        new ParallelClass.Person { Name="Grodon", City="Hulll"},
                                         new ParallelClass.Person { Name="Henry", City="Seattle"},
                                          new ParallelClass.Person { Name="Isaac", City="London"}
                         };

                    try
                    {
                        var result9 = from person in peopleNull.AsParallel()
                                      where ParallelClass.CheckCity(person.City)
                                      select person;


                        result9.ForAll(person => Console.WriteLine(person.Name));
                    }
                    catch (AggregateException e)
                    {
                        Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
                    }

                    Console.WriteLine("Finishing exception");
                    Console.ReadKey();
                    return true;

                case "10":
                    // Return a VALUER FROM a Task
                    // task.run -> uses TaskFactrory.StartNew 
                    // use de dafault task scheduler the .net uses THREAD POOL
                    Task<int> task = Task.Run(() =>
                    {
                        return ThreadClass.CalculateResult();
                    });
                    Console.WriteLine( task.Result);
                    Console.WriteLine("Finishing return");
                    Console.ReadKey();
                    return true;

                case "11":
                    // WAIT
                    // WaitAll(); // wait for all, task to end
                    // WaitAny pause until one task is complete

                    //  Task.WaitAll blocks the current thread until everything has completed.
                    //Task.WhenAll returns a task which represents the action of waiting until everything has completed.


                    Task[] tasks = new Task[10];

                    for (int i = 0; i < 10; i++)
                    {
                        int taskNum = i; // make a local copy of the loop counter so that
                                         // correct task number is passed into the lambda expression
                        tasks[i] = Task.Run(() => ThreadClass.DoWork(taskNum));
                    }

                    Task.WaitAll(); // wait for all, task to end
                                    //  Task.WaitAny(); // wait for any

                    Console.WriteLine("Finishing WAIT");
                    Console.ReadKey();
                    return true;

                case "12":
                    // Continuation Task     

                    Task task12 = Task.Run(() => ThreadClass.HelloTask());
                    task12.ContinueWith((prevTask) => ThreadClass.WorldTask());
                    
                    Console.WriteLine("Finishing return");
                    Console.ReadKey();
                    return true;

                case "13":
                    // Continuation Task Failure     

                    Task task13 = Task.Run(() => ThreadClass.HelloTaskFailure());

                    task13.ContinueWith((prevTask) => ThreadClass.WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);

                    task13.ContinueWith((prevTask) => ThreadClass.ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

                    Console.WriteLine("Finishing TASK FAILURE");
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
