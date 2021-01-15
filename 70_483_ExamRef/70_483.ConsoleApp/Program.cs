using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
            Console.WriteLine("1) Enum  ");
            Console.WriteLine("2) Struct  ");
            Console.WriteLine("3) Static Constructors  ");
            Console.WriteLine("4) Extensions  ");
            Console.WriteLine("5) Index property  ");
            Console.WriteLine("6) Dynamic  ");
            Console.WriteLine("7) ExpandoObject  ");
            Console.WriteLine("8) Enumarator  "); // 154
            Console.WriteLine("9) Enumerator  Class"); // 156
            Console.WriteLine("10) Attributes"); // 162
            Console.WriteLine("11) CodeDOM"); // 168
            Console.WriteLine("12)  Lambda Expression Trees"); // 170
            Console.WriteLine("13)  Use Func / Expression");// ****
            Console.WriteLine("14)  Assembly");// 172
            Console.WriteLine("15)  PropertyInfo");// 172
            Console.WriteLine("16)  MethodInfo");// 174

            Console.WriteLine("17)  GCollector");// 182
            Console.WriteLine("18)  StringWriter");// 185
            Console.WriteLine("19)  Formatting");// 191
            Console.WriteLine("20)  FormatProvider");// 192
            Console.WriteLine("21)  Interpolation");// 192

            Console.WriteLine("22)  Encaptulation via ");// 136

            Console.WriteLine("23)  CodeDom 2  ");// 169
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
                    Console.WriteLine("x {0}", swarm[0].ToString());

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
                case "6":
                    // Dynamic

                    dynamic d = new MessageDisplay();
                    d.DisplayMessage("hello");

                    dynamic m = new MessageDisplay();
                    m.banana("hello");

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "7":
                    // ExpandObject

                    dynamic person = new ExpandoObject(); // system.Dynamic
                    person.Name = "Ron";
                    person.Age = 21;

                    Console.WriteLine("Name: {0}", person.Name);

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "8":
                    // Enumerator

                    var stringEnumerator = "Hello World".GetEnumerator();
                    
                    while(stringEnumerator.MoveNext())
                    {
                        Console.WriteLine(stringEnumerator.Current );
                    }
                  
                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "9":
                    // Enumerator Class

                   
                    //IMPLEMENT ENUMERATOR

                    EnumeratorThing ething = new EnumeratorThing(10);

                    foreach (int i in ething)
                        Console.WriteLine(i);

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "10":
                    // Attributes

                    Attribute atr = Attribute.GetCustomAttribute(typeof(Person),
                        typeof(ProgrammerAttribute));

                    ProgrammerAttribute p = (ProgrammerAttribute)atr;
                    Console.WriteLine("Programmer: {0}" ,p.Programmer);

                    //var Attrs = Attribute.GetCustomAttributes(typeof(Person), typeof(ProgrammerAttribute));
                    var Attrs = Attribute.GetCustomAttributes(typeof(Person));

                    foreach (var item in Attrs)
                    {
                        ProgrammerAttribute pItem = (ProgrammerAttribute)item;
                        if (item is ProgrammerAttribute)
                        Console.WriteLine("PROGRAMMER: {0}",pItem.Programmer);
                    }

                    for (int i = 0; i < Attrs.Length; i++)
                    {
                        Console.WriteLine(Attrs[i].ToString());
                    }

                    Type myType = typeof(Person);
                    // Get the members associated with Person.
                    MemberInfo[] myMembers = myType.GetMembers();

                   /// Display the attributes for each of the members of Person.
                    for (int i = 0; i < myMembers.Length; i++)
                        {
                            object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                            if (myAttributes.Length > 0)
                            {
                                Console.WriteLine("\nThe attributes for the member {0} are: \n", myMembers[i]);
                                for (int j = 0; j < myAttributes.Length; j++)
                                    Console.WriteLine("The type of the attribute is {0}.", myAttributes[j]);
                            }
                        }


                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "11":
                    // codeDOM

                    //using CodeDom ;
                    CodeCompileUnit compilerUnit = new CodeCompileUnit();

                    //create a nameSpace to hold the Types we are going to create
                    CodeNamespace personnelNameSpace = new CodeNamespace("Personnel");
                    //import the namespace
                    personnelNameSpace.Imports.Add(new CodeNamespaceImport("System"));

                    //create a class
                    CodeTypeDeclaration personClass = new CodeTypeDeclaration("Person");
                    personClass.IsClass = true;
                    personClass.TypeAttributes = TypeAttributes.Public; //system.reflection

                    //class 2 
                    CodeTypeDeclaration orderClass = new CodeTypeDeclaration("Order");
                    orderClass.IsClass = true;
                    personClass.TypeAttributes = TypeAttributes.Sealed;


                    //Add personClass to NameSpace
                    personnelNameSpace.Types.Add(personClass);

                    personnelNameSpace.Types.Add(orderClass);

                    //create a field to hold the name of the Person
                    CodeMemberField nameField = new CodeMemberField("String", "name");
                    nameField.Attributes = MemberAttributes.Private;

                    // add the name field to thr Person Class
                    personClass.Members.Add(nameField);

                   
                    //add the nameSpace to the Document
                    compilerUnit.Namespaces.Add(personnelNameSpace);

                    // * Once the CodeDOM object has been created you can create a 
                    //   CodeDOMProvider to Parse the Code Document and produce the program code
                    // example: ->it sends the program code to string 

                    // send the document somewhere
                    // using Sytem.CodeDOM.Compiler 
                    CodeDomProvider provider =  CodeDomProvider.CreateProvider("CSharp"); //** 

                    //give the provider somewhere to send the parsed output
                    //Using System.IO
                    StringWriter s = new StringWriter();

                    // set the options to parse - we can use the default
                    CodeGeneratorOptions options = new CodeGeneratorOptions();

                    //generate the C# Source from the CodeDOM
                    provider.GenerateCodeFromCompileUnit(compilerUnit, s, options);
                    s.Close();

                    //Print the C# OUTPUT
                    Console.WriteLine(s.ToString());

                    Console.WriteLine("finishing codeDOM");
                    Console.ReadKey();
                    return true;

                case "12":
                    // Lambda Expression Trees

                    // System.Linq.Expression

                    //parameter for a expression is an integer
                    ParameterExpression numParam = Expression.Parameter(typeof(int), "num");

                    //the operation to be performed is to square  the parameter
                    BinaryExpression squareOperation = Expression.Multiply(numParam, numParam);

                    //this creates an expression tree that describes the queare operation
                    Expression<Func<int, int>> square = Expression.Lambda<Func<int, int>>(
                                                       squareOperation,
                                                       new ParameterExpression[]
                                                       { numParam});

                    //compile the tree to make an executable method and assign it to a delegate
                    Func<int, int> doSquare = square.Compile();

                    // call the delegate
                    Console.WriteLine("Square of: {0}", doSquare(4));

                    Console.WriteLine("Finishingv Lambda Expression Trees");
                    Console.ReadKey();
                    return true;

                case "13":
                    //use of FUNC
                     Func<Student, bool> isTeenAger = ss => ss.Age > 12 && ss.Age < 20;  //func can be place inside a switch, anywhere
                    bool isTeen =  isTeenAger(new Student() { Age = 34, StudentName = "SASASA", StudentID=1 });

                    Console.WriteLine("IsTeen: {0}",isTeen);

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "14":
                    //Assembly
                    Assembly assembly = Assembly.GetExecutingAssembly();

                    Console.WriteLine("FullName: {0}",assembly.FullName);

                    AssemblyName name = assembly.GetName();
                    Console.WriteLine("Mayor versioon {0}", name.Version.Major);
                    Console.WriteLine("Minor versioon {0}", name.Version.Minor);

                    Console.WriteLine("In Global : {0}", assembly.GlobalAssemblyCache);

                    foreach (Type moduleType in assembly.GetTypes())   // return classes , structs
                    {
                        Console.WriteLine("Type: {0}", moduleType.Name );

                        foreach (MemberInfo member in moduleType.GetMembers())
                        {
                            Console.WriteLine("Member: {0}", member);
                        }

                    }


                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "15":
                    //PropertyInfo

                    Type type = typeof(Student);

                    Type type2 = typeof(Student);

                   
                    foreach (PropertyInfo prop in type2.GetProperties())
                    {

                    }

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        Console.WriteLine("PropName: {0}", property.Name);
                        if (property.CanRead)
                        {
                            Console.WriteLine("GET methos: {0}", property.GetMethod);
                        }
                        if (property.CanWrite)
                        {
                            Console.WriteLine("SET method: {0}", property.SetMethod);
                        }
                    }

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

              

                case "16":
                    //methodInfo

                    Type type16 = typeof(Calculator);

                    //get method info
                    MethodInfo addintInfo = type16.GetMethod("AddInt");

                    //get the IL instrucctgion for the AddInt Method
                    MethodBody addIntBody = addintInfo.GetMethodBody();

                    //print the IL instructions
                    foreach (byte b in addIntBody.GetILAsByteArray())
                    {
                        Console.WriteLine(" {0:X}",b);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Create Calculator");
                    Calculator calc = new Calculator();
                    // parameter array
                    object[] inputs = new object[] { 1, 2 };

                    Console.WriteLine("Calls invoke on the methoid info");
                    int result = (int)addintInfo.Invoke(calc, inputs); // cast
                    Console.WriteLine("RESULT : {0}", result    );

                    //ConcatTypes
                    object[] inputsString = new object[] { "texto", 77 };
                    MethodInfo concatInfo = type16.GetMethod("ConcatTypes");
                    string resultString = (string)concatInfo.Invoke(calc, inputsString); // cast
                    Console.WriteLine("RESULT ConcatTypes: {0}", resultString);

                    Console.WriteLine("finishing extensions");
                    Console.ReadKey();
                    return true;

                case "17":
                    //DISPOSE / FINALIZER

                    ResourceHolder r = new ResourceHolder();

                    r.Dispose();

                    Console.WriteLine("finishing GC");
                    Console.ReadKey();
                    return true;

                case "18":
                    //StringWriter

                    StringWriter sw = new StringWriter();
                    sw.WriteLine("Hello sw");
                    sw.Close();

                    //Console.WriteLine(sw.ToString());

                    Console.WriteLine("finishing StringWriter");
                    Console.ReadKey();
                    return true;
                case "19":
                    //Formatt

                   MusicTrack song = new MusicTrack(artist: "Rob",title:"My Way");

                    Console.WriteLine("Track {0:F}", song);
                    Console.WriteLine("Track {0:A}", song);
                    Console.WriteLine("Track {0:T}", song);

                    Console.WriteLine("finishing Format");
                    Console.ReadKey();
                    return true;

                case "20":
                    //Formatt Provider
                    double bankBalance = 123.45;

                    //using SYtem globaliaztion
                    CultureInfo usProvider = new CultureInfo("en-US");
                    Console.WriteLine("Us Balance {0}",bankBalance.ToString("C", usProvider));

                    CultureInfo ukProvider = new CultureInfo("en-GB");
                    Console.WriteLine("UK Balance {0}", bankBalance.ToString("C", ukProvider));

                    Console.WriteLine("finishing formatprovider");
                    Console.ReadKey();
                    return true;

                case "21":
                    //Interpolation

                    string name21 = "Ron";
                    int age = 2564;

                    Console.WriteLine("YourName is {0} and your age is {1,8:D}", name21, age);

                    Console.WriteLine($"YourName is {name21} and your age is {age, -2:D}");
                    Console.WriteLine($"YourName is {name21} and your age is {age}");

                    // new

                    decimal[] amounts = { 16305.32m, 18794.16m };
                    Console.WriteLine("   Beginning Balance           Ending Balance");
                    Console.WriteLine("   {0,-17:C2} {1}", amounts[0] , "after"); //spaces after , to the right

                    //Console.WriteLine("   {0,-28:C2}{1,14:C2}", amounts[0], amounts[1]);


                    double bankBalance21 = 124.54;
                    //FormattableString balanceMessage = $"US balance: {bankBalance21:C}";
                    string balanceMessage = $"US balance: {bankBalance21:C}";
                    CultureInfo usProvider21 = new CultureInfo("en-US");
                    Console.WriteLine(balanceMessage.ToString(usProvider21));

                    Console.WriteLine("finishing Interpolation");
                    Console.ReadKey();
                    return true;

                case "22":
                    //Encapsulation via Interface

                    Report myReport = new Report();
                    // myReport  -> does not have the methods of the interface

                    IPrintable printItem = myReport;
                    printItem.GetPrintableText(5, 6); // now we can implement the interface


                    // implement Idispley
                    IDisplay displaydItem = myReport;
                    displaydItem.GetTitle(); // implement Idisplay
                    Console.WriteLine("finishing Encapsulation via Interface");
                    Console.ReadKey();
                    return true;

                case "23":
                    //CodeDom2
                    CodeCompileUnit compileUnit23 = new CodeCompileUnit();

                    // namespace to hold the types we are going to create
                    CodeNamespace nameSpace = new CodeNamespace("Personel");

                    //import the system namespace
                    nameSpace.Imports.Add(new CodeNamespaceImport("System"));

                    // creae a person class
                    CodeTypeDeclaration person23 = new CodeTypeDeclaration("Person");
                    person23.IsClass = true;
                    person23.TypeAttributes = System.Reflection.TypeAttributes.Public;

                    //Add the person class to namespace
                    nameSpace.Types.Add(person23);

                    // create a field to hold the name of the person
                    CodeMemberField nameField23 = new CodeMemberField("String", "name");
                    nameField23.Attributes = MemberAttributes.Private;

                    //add the name field to the person class
                    person23.Members.Add(nameField23);

                    // add the nameSpace to the document
                    compileUnit23.Namespaces.Add(nameSpace);

                    // ----  class order  ---*/
                    // creae a person class
                    CodeTypeDeclaration classOrder = new CodeTypeDeclaration("Order");
                    classOrder.IsClass = true;
                    classOrder.TypeAttributes = System.Reflection.TypeAttributes.Public;

                    CodeMemberField idOrder = new CodeMemberField("Int", "id");
                    idOrder.Attributes = MemberAttributes.Private;

                    // add the field
                    classOrder.Members.Add(idOrder);

                    CodeMemberMethod orderMethodGetId = new CodeMemberMethod();
                    orderMethodGetId.Name = "orderMethodGetId";
                    orderMethodGetId.ReturnType = new CodeTypeReference("System.string");
                    orderMethodGetId.Parameters.Add(new CodeParameterDeclarationExpression("System.String", "Text"));

                    // add method to class
                    classOrder.Members.Add(orderMethodGetId); // codememberMethod is of Type  CodeTypeMember

                    // add constructor
                    CodeConstructor constructor  = new CodeConstructor();//Create constructor
                    constructor.Attributes = MemberAttributes.Public;
                    classOrder.Members.Add(constructor);//Add constructor to class
                    
                    nameSpace.Types.Add(classOrder);


                    // **** 2 PART ***
                    // create a provider to parse the document
                    CodeDomProvider provider23 = CodeDomProvider.CreateProvider("CSharp");
                    // give the provider somewhere to send and parsed output

                    /**/

                    StringWriter s23 = new StringWriter();

                    //some options for the pase - we can use defaults
                    CodeGeneratorOptions options23 = new CodeGeneratorOptions();

                    // generate the C# source from the CodeDOM
                    provider23.GenerateCodeFromCompileUnit(compileUnit23, s23, options23);
                    s23.Close();

                    // print the C# output
                    Console.WriteLine(s23.ToString());
              
                 
                    Console.WriteLine("finishing CodeDom 2");
                    Console.ReadKey();
                    return true;
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }

        }

        // fUNC
        static Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
       //static  Func<Student, bool> isTeenAger = isTeenAgerExpr.Compile();
      

        Func<Student, bool> isOld = s => s.Age > 40;

        Func<string, bool> largename = n => n.Length > 5;
        //Eend func


        enum AlineStateNormal
        {
            Sleeping,
            Attacking,
            Destroyed
        }
        enum AlienState :
            byte
        {
            Sleeping = 1,
            Attacking = 2,
            Destroyed = 4
        };
    }

    struct Alien
    {
        public int X;
        public int Y;
        public int Lives;

        public Alien(int x, int y)
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
                };
            }
        }
    }

    // dynamic
    class MessageDisplay
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    // MAKE OBJECT ENUMERABLE

    class EnumeratorThing : IEnumerator<int> , IEnumerable
    {
        int count;
        int limit;

        public int Current
        {
            get
            {
                return count;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return count;
            }
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (++count == limit)
                return false;
            else
                return true;
        }

        public void Reset()
        {
            count = 0;
        }

        public IEnumerator GetEnumerator() //IEnumerable implements
        {
            return this;
        }

        public EnumeratorThing (int limit)
        {
            count = 0;
            this.limit = limit;
        }
    }

    // Attributes
    [AttributeUsage(AttributeTargets.Class)] //Controlling Attributes
    class ProgrammerAttribute: Attribute
    {
        private string programmerVale;

        public ProgrammerAttribute(string programmer)
        {
            programmerVale = programmer;
        }
        public string Programmer
        { get { return programmerVale; } }

    }
     [ProgrammerAttribute(programmer:"Fred")]
    class Person
    {
        public string Name { get; set; }
    }

    // Expression 

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

    }

    //METHODINFO
    
    public class Calculator
    {
        public int AddInt(int v1, int v2)
        {
            return v1 + v2;
        }

        public string ConcatTypes(string str1, int intToConvert)
        {
            return str1 + intToConvert.ToString();
        }
    }

    // IDISPOSABLE  -- 182

    class ResourceHolder: IDisposable
    {
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Not to be called for GC because it has been disposed
        }

        public void Dispose (bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //free any managed object
            }

            // Free any UNMANAGED Object
        }

        ~ResourceHolder()
        {
            // dispose only of UNMANAGED OBJECTS
            Dispose(false);
        }
    }

    // FORMATER

    class MusicTrack: IFormattable
    {
        public string Artist { get; set; }
        public string Title { get; set; }

        //tostring that implelmets the formatting behavior
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
                format = "G";

            switch (format)
            {
                case "A": return Artist;
                case "T": return Title;
                case "G": // DEFAULT 
                case "F": return Artist + " " +  Title;
                    
                default:
                    throw new FormatException("Format specifier was invalid");
            }

        }

        //string that overrides the behavior in the base class
        public override string ToString()
        {
            return Artist + " " + Title;
        }

        public MusicTrack(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }
    }

    //Interface Encapsulation
    interface IPrintable
    {
        string GetPrintableText(int pageWidth, int pageHeight);
        string GetTitle();
    }

    interface IDisplay
    {
        string GetTitle();
    }

    public class Report : IPrintable , IDisplay
    {
        //public string GetPrintableText(int pageWidth, int pageHeight)
        //{
        //    return "GetPrintableText from  report";
        //}
         string IPrintable.GetPrintableText(int pageWidth, int pageHeight)
        {
            return "Report text to be printed";
        }

         string IPrintable.GetTitle()
        {
            return "Report title to be printed";
        }

        string IDisplay.GetTitle()
        {
            return "Report title to be displayed";
        }
    }

}
