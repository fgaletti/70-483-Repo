using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("1) Arrays ");
            Console.WriteLine("2) Multidimentional ");
            Console.WriteLine("3) Jagged Arrays ");
            Console.WriteLine("4) List ");
            Console.WriteLine("5) Dictionary ");
            Console.WriteLine("6) Dictionary 2 ");
            Console.WriteLine("7) Set ");
            Console.WriteLine("8) HashSet Union ");
            Console.WriteLine("9) QUEUE ");
            Console.WriteLine("10) STACK ");
            Console.WriteLine("11) Initialize Collections ");
            Console.WriteLine("12) Add and Reemove ITEMS from Array ");
            Console.WriteLine("13) Add and Reemove ITEMS in ARRAYLIST AND LIST ");

            Console.WriteLine("14) Add and Reemove ITEMS from a Dictionary ");
            Console.WriteLine("15) Add and Reemove ITEMS from a SET ");
            Console.WriteLine("16) Implementing Custom Collections ");
            Console.WriteLine("17) Implementing Collection Interfaces ");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":

                    int[] intArray = new int[5];

                    intArray[0] = 99;
                    intArray[4] = 100;

                    for (int i = 0; i < intArray.Length; i++)
                    {
                        Console.WriteLine(intArray[i]);
                    }

                    foreach (int intValue in intArray)
                    {
                        Console.WriteLine(intValue);
                    }

                    //initialize
                    int[] intArrayIni = new int[6] { 0, 1, 2, 3, 4, 5 };

                    

                    Console.WriteLine("finishing Array");
                    Console.ReadKey();
                    return true;
                case "2":
                    // Multidimentional
                    string[,] compass = new string[3, 3]
                    {
                        {"NW", "N", "NE" },
                        {"W", "C", "E" },
                        {"SW", "S", "SE" }
                    };

                    Console.WriteLine(compass[0,2]);
                    Console.WriteLine(compass[2, 1]);

                    string[,] compass2 = new string[2, 3];
                    compass2[0, 0] = "A1";
                    compass2[0, 1] = "A2";
                    compass2[0, 2] = "A3";
                    compass2[1, 0] = "B1";
                    compass2[1, 1] = "B2";
                    compass2[1, 2] = "B3";

                    for (int i = 0; i < compass2.GetLength(0); i++)
                    {
                        for (int j = 0; j < compass2.GetLength(1); j++)
                        {
                            Console.WriteLine(compass2[i,j]);
                        }
                    }

                    Console.WriteLine("finishing Multidimentional");
                    Console.ReadKey();
                    return true;
                case "3":
                    // Jagged Arrays

                    int[][] jagged = new int[][]
                        {
                            new int[] {1,2,3,4},
                            new int[] {5,6},
                            new int[] {7,8}
                        };

                    int[][] jaggedArray2 = new int[2][];

                    jaggedArray2[0] = new int[3] { 1, 2, 3 };
                    jaggedArray2[1] = new int[2] ;
                    jaggedArray2[1][0] = 77;
                    jaggedArray2[1][1] = 78;

                    Console.WriteLine("finishing Multidimentional");
                    Console.ReadKey();
                    return true;
                case "4":
                    // Lsit

                    List<string> names = new List<string>();

                    names.Add("Rob");
                    names.Add("Imm");

                    for (int i = 0; i < names.Count; i++)
                    {
                        Console.WriteLine(names[i]);
                    }

                    names[0] = "Changed";
                    foreach (string item in names)
                    {
                        Console.WriteLine(item);
                    }
                    
                    Console.WriteLine("finishing Names");
                    Console.ReadKey();
                    return true;

                case "5":
                    // Dictionary

                    BanckAccount a1 = new BanckAccount()
                    {
                        AccountNo = 1,
                        Name = "Rom"
                    };
                    BanckAccount a2 = new BanckAccount() { AccountNo = 2, Name = "Immi" };

                    Dictionary<int, BanckAccount> bank = new Dictionary<int, BanckAccount>();

                    bank.Add(a1.AccountNo, a1);
                    bank.Add(a2.AccountNo, a2);

                    Console.WriteLine(bank[1]);

                    if (bank.ContainsKey(2))
                        Console.WriteLine("Account located");

                    Console.WriteLine("finishing Dictionary");
                    Console.ReadKey();
                    return true;
                case "6":
                    // Dictionary 2

                    Dictionary<string, int> counters = new Dictionary<string, int>();

                    string text = File.ReadAllText("input.txt");

                    string[] words = text.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        string lowWord = word.ToLower();
                        if (counters.ContainsKey(lowWord))
                        {
                            counters[lowWord]++;  
                        }
                        else
                        {
                            counters.Add(lowWord, 1);
                        }
                    }


                    foreach (var item in counters)
                    {
                        Console.WriteLine("{0}:{1}", item.Key, item.Value);
                    }

                    Console.ReadKey();

                    var items = from pair in counters
                                orderby pair.Value descending
                                select pair;

                    foreach (var item in items)
                    {
                        Console.WriteLine("{0}: {1}", item.Key, item.Value);
                    }



                    Console.WriteLine("finishing Dictionary 2");
                    Console.ReadKey();
                    return true;
                case "7":
                    // HASHSET
                    HashSet<string> t1Styles = new HashSet<string>();
                    t1Styles.Add("Electronic");
                    t1Styles.Add("Disco");
                    t1Styles.Add("Fast");

                    HashSet<string> t2Styles = new HashSet<string>();
                    t2Styles.Add("Classical");
                    t2Styles.Add("Fast");

                    HashSet<string> search = new HashSet<string>();
                    search.Add("Fast");
                    search.Add("Disco");

                    if (search.IsSubsetOf(t1Styles))
                        Console.WriteLine("All sear style present in T1");

                    if (search.IsSubsetOf(t2Styles))
                        Console.WriteLine("All sear style present in T2");


                    Console.WriteLine("finishing HASHSET");
                    Console.ReadKey();
                    return true;

                case "8":
                    // hashset

                    HashSet<int> evenNumbers = new HashSet<int>();
                    HashSet<int> oddNumbers = new HashSet<int>();

                    for (int i = 0; i < 5; i++)
                    {
                        // Populate numbers with just even numbers.
                        evenNumbers.Add(i * 2);

                        // Populate oddNumbers with just odd numbers.
                        oddNumbers.Add((i * 2) + 1);
                    }

                  

                    // Create a new HashSet populated with even numbers.
                    HashSet<int> numbers = new HashSet<int>(evenNumbers);
                    Console.WriteLine("numbers UnionWith oddNumbers...");
                    numbers.UnionWith(oddNumbers);

                    Console.Write("numbers contains {0} elements: ", numbers.Count);

                    foreach (int     item in numbers)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("finishing hasset union");
                    Console.ReadKey();
                    return true;

                case "9":
                    // QUEUE

                    Queue<string> demoQueue = new Queue<string>();

                    demoQueue.Enqueue("Rob");
                    demoQueue.Enqueue("Immi");

                    Console.WriteLine(demoQueue.Dequeue());
                    Console.WriteLine(demoQueue.Dequeue());

                    Console.WriteLine("finishing QUEUE");
                    Console.ReadKey();
                    return true;

                case "10":
                    // STACK
                    // FIFO
                    Stack<string> demoStack = new Stack<string>();

                    demoStack.Push("Rob");
                    demoStack.Push("Immy");

                    Console.WriteLine(demoStack.Pop());
                    Console.WriteLine(demoStack.Pop());

                    Console.WriteLine("finishing STACK");
                    Console.ReadKey();
                    return true;

                case "11":
                    // INITIALIZE COLLECTIONS 

                    int[] arrayInt = { 1, 2, 3, 4 };

                    //use System.Collections
                    ArrayList arrayList = new ArrayList { 1, "Dos", 3 };

                    List<int> list = new List<int> { 1, 2, 3, 4 };

                    Dictionary<int, string> dictionary = new Dictionary<int, string>
                    {
                        { 1 , "Uno dict" },
                        { 2 , "Dos " }
                    };

                    HashSet<string> hash = new HashSet<string> { "Electronic", "Disco" };

                    // patentesis, new array[] 
                    Queue<string> queue = new Queue<string> ( new string[] { "Rom", "Immi" } );

                    Stack<string> stack = new Stack<string>(new string[] { "Rom", "Immi" });


                    Console.WriteLine("finishing INITIALIZE COLLECTIONS ");
                    Console.ReadKey();
                    return true;

                case "12":
                    // Add Remode data from Array

                    //GROW AN ARRAY
                    int[] dataArray = { 1, 2, 3, 4 };
                    int[] tempArray = new int[5];
                    dataArray.CopyTo(tempArray, 0);
                    dataArray = tempArray;

                    Console.WriteLine("finishing Add Remode data from Array");
                    Console.ReadKey();
                    return true;
                case "13":
                    // Add Remode data in ArrayList and LIST

                    List<string> list13 = new List<string>();
                    list13.Add("add to the end ");
                    list13.Insert(0, "insert at start");
                    list13.Insert(1, "insert new item 1");

                    list13.InsertRange(2, new string[] { "Rob", "Immy" }); //insert a ragne 
                    list13.Remove("Rob");
                    list13.RemoveAt(0);
                    list13.RemoveRange(1, 2);
                    list13.Clear();

                    Console.WriteLine("finishing Add Remode data in ArrayList and LIST");
                    Console.ReadKey();
                    return true;
                case "14":
                    // Add Remove Items from a Dictionary

                    Dictionary<int, string> dictionary14 = new Dictionary<int, string>();
                    dictionary14.Add(1, "Rob");
                    dictionary14.Remove(1); // Remove from key
                    
                    Console.WriteLine("finishing Add Remove Items from a Dictionary");
                    Console.ReadKey();
                    return true;
                case "15":
                    // Add Remove Items from SET

                    HashSet<string> set = new HashSet<string>();
                    set.Add("Rob");
                    //set.Remove("Rob");
                    set.RemoveWhere(x => x.StartsWith("R"));

                    Console.WriteLine("finishing Add Remove Items from a SET");
                    Console.ReadKey();
                    return true;
                case "16":
                    // Custom Collections

                    TrackStore trStore = new TrackStore();
                    trStore.Add(new MusicTrack() { Artist = "Rob", Length = 1, Title = "My WAy", test = "" });
                    trStore.Add(new MusicTrack() { Artist = "Immi", Length = 1, Title = "Your WAy", test = "" });
                    trStore.Add(new MusicTrack() { Artist = "Rob", Length = 2, Title = "Otro disco", test = "" });
                    trStore.Add(new MusicTrack() { Artist = "Rob", Length = 3, Title = "3 discoS", test = "" });

                    trStore.RemoveArtist("Rob");

                    foreach (MusicTrack track in trStore)
                    {
                        Console.WriteLine("{0}: {1}", track.Artist, track.Title);
                    }

                    Console.WriteLine("finishing  Custom Collections");
                    Console.ReadKey();
                    return true;
                case "17":
                    // Implementing Collection Interfaces
                    CompassCollection compassCol = new CompassCollection();

                    foreach (string item in compassCol)
                    {
                        Console.WriteLine(item);

                    }

                    CompassCollectionLinq compassLinq = new CompassCollectionLinq();

                    var linqCompass = from comp in compassLinq
                                      select comp;


                    Console.WriteLine("finishing  Implementing Collection Interfaces");
                    Console.ReadKey();
                    return true;

                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

        public class BanckAccount
        {
            public int AccountNo { get; set; }
            public string Name { get; set; }
        }

        //own collection
        class MusicTrack
        {
            public string Artist { get; set; }
            public string Title { get; set; }
            public int Length { get; set; }
            public string test { get; set; }
        }

        class TrackStore: List<MusicTrack>
        {
            public int RemoveArtist(string removeName)
            {
                List<MusicTrack> removeList = new List<MusicTrack>();
                foreach (MusicTrack track in this)
                {
                    if (track.Artist == removeName)
                        removeList.Add(track);
                }
                foreach (MusicTrack track in removeList)
                {
                    this.Remove(track);
                }

                return removeList.Count();
            }
        }

        //Implement collection interfaces
        class CompassCollection: ICollection
        {
            //Array containing values in this collection
            string[] compassPoints = { "North", "South", "East", "West" };

            //count property to return lenght of the collections
            public int Count
            {
                get { return compassPoints.Length; }
            }         
            // retuns an object that can be uses to Syncrhonise
            // access to this objects
            public object SyncRoot { get { return this; } }

            // returns TRUE if the collection is thread safe
            // this collections is NOT
            public bool IsSynchronized
            {
                get { return false; }
            }

            //provide a copy to behavior
            public void CopyTo(Array array, int index)
            {
                foreach (string point in compassPoints)
                {
                    array.SetValue(point, index);
                    index = index + 1;
                }
            }

            //required for enumerate
            //returns enumerator from the embedded array
            public IEnumerator GetEnumerator()
            {
                return compassPoints.GetEnumerator();
            }
        }

        // Collection implements Linq
        //Implement collection interfaces
        class CompassCollectionLinq :  IEnumerable<string>
        {
            //Array containing values in this collection
            // string[] compassPoints = { "North", "South", "East", "West" };

            List<string> compassPoints;
            //count property to return lenght of the collections
            public int Count
            {
                get { return compassPoints.Count(); }
            }
            // retuns an object that can be uses to Syncrhonise
            // access to this objects
            public object SyncRoot { get { return this; } }

            // returns TRUE if the collection is thread safe
            // this collections is NOT
            public bool IsSynchronized
            {
                get { return false; }
            }

            //provide a copy to behavior
            public void CopyTo(Array array, int index)
            {
                foreach (string point in compassPoints)
                {
                    array.SetValue(point, index);
                    index = index + 1;
                }
            }

            //required for enumerate
            //returns enumerator from the embedded array
            //public  IEnumerator GetEnumerator()
            //{
            //    return compassPoints.GetEnumerator();
            //}

            //IEnumerator<string> IEnumerable<string>.GetEnumerator()
            //{
            //    return  compassPoints.GetEnumerator();
            //}

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.compassPoints.GetEnumerator();
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                Console.WriteLine("HERE");
                return compassPoints.GetEnumerator();
            }

        }

        //
        class Example : IEnumerable<string>
        {
            List<string> _elements;

            public Example(string[] array)
            {
                this._elements = new List<string>(array);
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                Console.WriteLine("HERE");
                return this._elements.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this._elements.GetEnumerator();
            }
        }
    }
}
