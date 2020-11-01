using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
    public class TaskClass
    {
        public static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }

        public static void DoWork(int i)
        {
            Console.WriteLine("Task {0} starting", i);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} finishing", i);
        }

        // continuation 

        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        // error
        public static void HelloTaskFailure()
        {
            Thread.Sleep(1000);
            Console.WriteLine("WorldTaskFailure");
            throw new Exception();  // 
        }
        public static void ExceptionTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Exceptionn");
        }
        // end continuation 

        // attached
        public static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(500);
            Console.WriteLine("Child {0} finished", state);
        }


        // Demonstrates:
        //      BlockingCollection<T>.Add()
        //      BlockingCollection<T>.Take()
        //      BlockingCollection<T>.CompleteAdding()
        public static async void BC_AddTakeCompleteAdding()  // change Void instead of Task
        {
            using (BlockingCollection<int> bc = new BlockingCollection<int>())
            {
                // Spin up a Task to populate the BlockingCollection
                Task t1 = Task.Run(() =>
                {
                    bc.Add(1);
                    bc.Add(2);
                    bc.Add(3);
                    Console.WriteLine("CompleteAdding 33");

                    bc.Add(4);
                    bc.Add(5);
                    bc.Add(6);
                    bc.Add(7);
                    bc.Add(8);
                    bc.Add(9);
                    bc.Add(10);
                    bc.Add(11);
                    bc.Add(12);
                    bc.Add(13);

                    bc.CompleteAdding();
                    Console.WriteLine("CompleteAdding");
                });

                // Spin up a Task to consume the BlockingCollection
                Task t2 = Task.Run(() =>
                {
                    try
                    {
                        // Consume consume the BlockingCollection
                        while (true) Console.WriteLine(bc.Take());
                    }
                    catch (InvalidOperationException)
                    {
                        // An InvalidOperationException means that Take() was called on a completed collection
                        Console.WriteLine("That's All!");
                    }
                });

               // await Task.WhenAll(t1, t2);
            }
        }

        // Demonstrates:
        //      BlockingCollection<T>.Add()
        //      BlockingCollection<T>.CompleteAdding()
        //      BlockingCollection<T>.TryTake()
        //      BlockingCollection<T>.IsCompleted
        public static void BC_TryTake()
        {
            // Construct and fill our BlockingCollection
            using (BlockingCollection<int> bc = new BlockingCollection<int>())
            {
                int NUMITEMS = 10000;
                for (int i = 0; i < NUMITEMS; i++) bc.Add(i);
                bc.CompleteAdding();
                int outerSum = 0;

                // Delegate for consuming the BlockingCollection and adding up all items
                Action action = () =>
                {
                    int localItem;
                    int localSum = 0;

                    while (bc.TryTake(out localItem)) localSum += localItem;
                    Interlocked.Add(ref outerSum, localSum);
                };

                // Launch three parallel actions to consume the BlockingCollection
                Parallel.Invoke(action, action, action);

                Console.WriteLine("Sum[0..{0}) = {1}, should be {2}", NUMITEMS, outerSum, ((NUMITEMS * (NUMITEMS - 1)) / 2));
                Console.WriteLine("bc.IsCompleted = {0} (should be true)", bc.IsCompleted);
            }
        }

    }
}
