using System;
using System.Collections.Concurrent;
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
            Console.WriteLine("14)  Attached Child");

            Console.WriteLine("15)  Thread1");
            Console.WriteLine("16)  ThreadStart Old .NET"); // ThreadStart delegate old .net versions
            Console.WriteLine("17)  Thread Lambda ");
            Console.WriteLine("18)  Thread Parametrized pm");
            Console.WriteLine("19)  Thread Parametrized Lambda ");
            Console.WriteLine("20)  Thread Abort ");
            Console.WriteLine("21)  Thread Abort Variable ");
            Console.WriteLine("22)  Thread Syncronization using Join ");
            Console.WriteLine("23)  Thread Data Storage and ThreadLocal");
            Console.WriteLine("24)  Thread Execution Context");
            Console.WriteLine("25)  Thread Pool");

            Console.WriteLine("26)  BlockingCollection");
            Console.WriteLine("27)  ConcurrentQueue");
            Console.WriteLine("28)  ConcurrentStack");
            Console.WriteLine("29)  ConcurrentBag");
            Console.WriteLine("30)  ConcurrentDictionary");

            Console.WriteLine("31)  BlockingCollection 2");

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
                        return TaskClass.CalculateResult();
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
                        tasks[i] = Task.Run(() => TaskClass.DoWork(taskNum));
                    }

                    Task.WaitAll(); // wait for all, task to end
                                    //  Task.WaitAny(); // wait for any
                   

                    Console.WriteLine("Finishing WAIT");
                    Console.ReadKey();
                    return true;

                case "12":
                    // Continuation Task     

                    Task task12 = Task.Run(() => TaskClass.HelloTask());
                    task12.ContinueWith((prevTask) => TaskClass.WorldTask());
                    
                    Console.WriteLine("Finishing return");
                    Console.ReadKey();
                    return true;

                case "13":
                    // Continuation Task Failure     

                    Task task13 = Task.Run(() => TaskClass.HelloTaskFailure());

                    task13.ContinueWith((prevTask) => TaskClass.WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);

                    task13.ContinueWith((prevTask) => TaskClass.ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

                    Console.WriteLine("Finishing TASK FAILURE");
                    Console.ReadKey();
                    return true;

                case "14":
                    //Attached Child 

                    var parent = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Parents Starts");
                        for (int i = 0; i < 10; i++)
                        {
                            int taskNo = i;
                            Task.Factory.StartNew((x) =>
                             TaskClass.DoChild(x),
                             taskNo,
                             TaskCreationOptions.AttachedToParent);
                        }
                    });

                    parent.Wait();

                    Console.WriteLine("Finishing PARENT");
                    Console.ReadKey();
                    return true;

                case "15":
                    //Thread 1 

                   Thread thread = new Thread(ThreadClass.ThreadHello);
                   thread.Start();

                    Console.WriteLine("Finishing ThreadStart  ");
                    Console.ReadKey();
                    return true;

                case "16":
                    //ThreadStart Old .NET 

                    ThreadStart ts = new ThreadStart(ThreadClass.ThreadHello);
                    Thread thread16 = new Thread(ts);
                    thread16.Start();

                    Console.WriteLine("Finishing ThreadStart Old .NET ");
                    Console.ReadKey();
                    return true;

                case "17":
                    //Thread Lambda Expression

                    Thread thread17 = new Thread(() =>
                    {
                        
                        Thread.Sleep(2000);
                        Console.WriteLine("Hello from Thread");
                    });

                    thread17.Start();

                    Console.WriteLine("Finishing Thread Lambda Expression");
                    Console.ReadKey();
                    return true;


                case "18":
                    //Parametrized Data

                    ParameterizedThreadStart pm = new ParameterizedThreadStart(ThreadClass.WorkOnData);
                    Thread thread18 = new Thread(pm);
                    thread18.Start(99);

                    Console.WriteLine("Finishing Parametrized Data");
                    Console.ReadKey();
                    return true;


                case "19":
                    //Parametrized Data Lambda

                    Thread thread19 = new Thread((data19) =>
                    {
                        Console.WriteLine("Working on: {0}", data19);
                        Thread.Sleep(2000);
                    });

                    thread19.Start(19);

                    Console.WriteLine("Finishing Parametrized Data Lambda");
                    Console.ReadKey();
                    return true;

                case "20":
                    //Abort Thread 
                    Thread thread20 = new Thread(() =>
                    {
                        while (true)
                        {
                            Console.WriteLine("Tick");
                            Thread.Sleep(1000);
                        }
                    });

                    thread20.Start();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    thread20.Abort();

                    Console.WriteLine("Finishing Abort");
                    Console.ReadKey();
                    return true;

                case "21":
                    //Abort Thread Correct ,using a variable
                    bool tickRunning = true;

                    Thread thread21 = new Thread(() =>
                    {
                        while (tickRunning) // this is better that the previous example, it stops before doing some tasks
                        {
                            Console.WriteLine("Tick");
                            Thread.Sleep(1000);
                        }
                    });

                    thread21.Start();
                    Console.WriteLine("Press any key to stop the clock");
                    Console.ReadKey();
                    tickRunning = false;

                    Console.WriteLine("Finishing Abort Thread Correct ,using a variable");
                    Console.ReadKey();
                    return true;

                case "22":
                    //Thread Syncronization using Join

                    Thread threadToWaitFor = new Thread(() =>
                    {
                        Console.WriteLine("Thread Starting");
                        Thread.Sleep(4000);
                        Console.WriteLine("Thread done");
                    });

                    threadToWaitFor.Start();
                    Console.WriteLine("Joining Thread");
                    threadToWaitFor.Join(); //join to MAIN THREAD  is this line is comment 
                                            // main thread accept Readkey and  threadToWaitFor
                                            // would be running in the background
                    Console.WriteLine("Press a key to exit");
                    Console.ReadKey();
                    
                    Console.WriteLine("Finishing Thread Syncronization using Join");
                    Console.ReadKey();
                    return true;

                case "23":
                    //Thread Data Storage and ThreadLocal

                    Thread t1 = new Thread(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("t1: {0}", ThreadClass.randomGenerator.Value.Next(10));
                            Thread.Sleep(500);
                        }
                    });

                    Thread t2 = new Thread(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("t2: {0}", ThreadClass.randomGenerator.Value.Next(10));
                            Thread.Sleep(500);
                        }
                    });

                    t1.Start();
                    t2.Start();
                    Console.ReadKey();

                    Console.WriteLine("Finishing Thread Data Storage and ThreadLocal");
                    Console.ReadKey();
                    return true;

                case "24":
                    //Thread Execution Context

                    Thread.CurrentThread.Name = "Main Method";
                    ThreadClass.DisplayThread(Thread.CurrentThread);

                    Console.WriteLine("Finishing Thread Execution Context");
                    Console.ReadKey();
                    return true;

                case "25":
                    //Thread Pool
                    // ThreadPool does not overwhelm a device. 
                    // extra threads are out in the queue.

                    // not good :
                    /*
                      -largen number of thread that MAY BE IDLE for very long time -> block the threadPool
                      
                      -cannot manage priority of threads in the threadPool
                      -Threads in threadPOOL have a background Pririty
                      - Local state variables are not cleared when a ThreadPool thread is REUSED.
                        They should not be used.
                      */
                    for (int i = 0; i < 10; i++)
                    {
                        int stateNumber = i;
                        ThreadPool.QueueUserWorkItem(state => ThreadClass.DoWork(stateNumber));  
                    }

                    Console.WriteLine("Finishing Thread Pool");
                    Console.ReadKey();
                    return true;

                case "26":
                    //BlockingCollection
                    //
                    BlockingCollection<int> data = new BlockingCollection<int>(5);

                    Task.Run(() =>
                    {
                        // attemp to add 20 items to the collectionn - blocks after 5th
                        for (int i = 0; i < 11; i++)
                        {
                            data.Add(i);
                            Console.WriteLine("Data {0} added succefully", i);
                        }
                        data.CompleteAdding();
                    });

                    Console.ReadKey();
                    Console.WriteLine("Reading Collection");

                    Task.Run(() =>
                    {
                        while (!data.IsCompleted)
                        {
                            try
                            {
                                int v = data.Take();
                                Console.WriteLine("Data {0} TAKEN succefully", v);
                            }
                            catch (InvalidOperationException)
                            {

                                throw;
                            }
                        }
                    });

                    Console.ReadKey();
                    Console.WriteLine("Finishing BlockingCollection");
                    Console.ReadKey();
                    return true;

                case "27":
                    //ConcurrentQueue
                    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
                    queue.Enqueue("Rob");
                    queue.Enqueue("Niles");

                    string str;
                    if (queue.TryPeek(out str)) // top
                    {
                        Console.WriteLine("Peek: {0}", str);
                    }
                  
                    if (queue.TryDequeue(out str)) // first in-first out (Rob is first)
                    {
                        Console.WriteLine("Dequeue: {0}", str);
                    }

                    Console.ReadKey();
                    Console.WriteLine("Finishing ConcurrentQueue");
                    Console.ReadKey();
                    return true;

                case "28":
                    //ConcurrentStack
                    ConcurrentStack<string> stack = new ConcurrentStack<string>();
                    stack.Push("Rob");
                    stack.Push("Miles");
                    stack.Push("Hull");

                    string str28;
                    if (stack.TryPeek(out str)) // top
                    {
                        Console.WriteLine("Peek: {0}", str);
                    }

                    if (stack.TryPop(out str)) // LAST in-first out (Rob is first)
                    {
                        Console.WriteLine("Dequeue: {0}", str);
                    }

                    Console.ReadKey();
                    Console.WriteLine("Finishing ConcurrentStack");
                    Console.ReadKey();
                    return true;

                case "29":
                    //ConcurrentBag
                    // when the order in which they are added/removed 
                    // is not important
                    ConcurrentBag<string> bag= new ConcurrentBag<string>();
                    bag.Add("Rob");
                    bag.Add("Miles");
                    bag.Add("Hull");

                    string str29;
                    if (bag.TryPeek(out str)) // no garantie 
                    {
                        Console.WriteLine("Peek: {0}", str);
                    }

                    if (bag.TryTake(out str)) // no garantie 
                    {
                        Console.WriteLine("Dequeue: {0}", str);
                    }

                    Console.ReadKey();
                    Console.WriteLine("Finishing ConcurrentBag");
                    Console.ReadKey();
                    return true;

                case "30":
                    //ConcurrentDictionary
                    // 

                    ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();
                    if (ages.TryAdd("Rob", 21))
                        Console.WriteLine("Rob Added");

                    Console.WriteLine("Robs age: {0}", ages["Rob"]);

                    if (ages.TryUpdate("Rob", 22, 21))
                        Console.WriteLine("Age updated");

                    Console.WriteLine("Robs NEW age: {0}", ages["Rob"]);

                    //Increment Robs age automacally using factory method
                    Console.WriteLine("Robs age udpated to {0} :",
                        ages.AddOrUpdate("Rob", 1, (name, age) => age = age + 1));

                    Console.WriteLine("Robs new age: {0} ", ages["Rob"]);

                    Console.ReadKey();
                    Console.WriteLine("Finishing ConcurrentDictionary");
                    Console.ReadKey();
                    return true;

                case "31":
                    //ConcurrentDictionary 2
                    // 
                     TaskClass.BC_AddTakeCompleteAdding();
                    //TaskClass.BC_TryTake();


                    Console.ReadKey();
                    Console.WriteLine("Finishing ConcurrentDictionary");
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
