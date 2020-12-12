using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            Console.WriteLine("1) JsonConvert  ");
            Console.WriteLine("2) XmlSerialazer  ");
            Console.WriteLine("3) Json Exception ");
            Console.WriteLine("4) Regular Expressions ");
            Console.WriteLine("5) Regular Expressions Multiple Spaces");
            Console.WriteLine("6) Data Validation using Regular Expressions ");
            Console.WriteLine("7) Data Validation End Numbers ");
            Console.WriteLine("8) Perfect Validation");

            Console.WriteLine("9) Regex Basic");
            Console.WriteLine("10) Regex Compile");
            Console.WriteLine("11) Regex Options");
            Console.WriteLine("12) Escapes");
            Console.WriteLine("13) Character Set");
            Console.WriteLine("14) Quantifiers");


            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":

                    MusicTrack track = new MusicTrack(artist: "Rob", title: "My way", lenght: 12);

                    string json = JsonConvert.SerializeObject(track);
                    Console.WriteLine("Json {0}", json );

                    MusicTrack trackRead = JsonConvert.DeserializeObject<MusicTrack>(json);
                    Console.WriteLine("Read back");
                    Console.WriteLine(trackRead);

                    //List
                    List<MusicTrack> album = new List<MusicTrack>();

                    string[] trackNames = new string[] { "My Way", "Your Way", "Their Way", "wrong way" };

                    foreach (string name in trackNames)
                    {
                        album.Add(new MusicTrack(artist: "Ron", title: name, lenght: 120));
                    }

                    string jsonArray = JsonConvert.SerializeObject(album);
                    Console.WriteLine("arrayJson {0}",jsonArray);
                    Console.WriteLine();

                    List<MusicTrack> readArray = JsonConvert.DeserializeObject<List<MusicTrack>>(jsonArray);
                    foreach (MusicTrack trackItem in readArray)
                    {
                        Console.WriteLine("arrayObject:  {0}", trackItem);
                    }

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":

                    // define class to serialize
                    MusicTrack2 track2 = new MusicTrack2(); //PARAMetless constructor
                    track2.Artist = "rommm";
                    track2.Title = "TTT";
                    track2.Lenght = 1222;
                    // define XmlSerializer
                    XmlSerializer trackSerializer = new XmlSerializer(typeof(MusicTrack2));
                    // create TextWriter
                    TextWriter serWriter = new StringWriter();
                    // Serialize
                    trackSerializer.Serialize(textWriter: serWriter, o: track2);

                    string trackXml = serWriter.ToString();
                    Console.WriteLine("Track Xml");
                    Console.WriteLine(trackXml);

                    //Read Xml
                    TextReader reader = new StringReader(trackXml);
                    MusicTrack2 trackReaderBack = trackSerializer.Deserialize(reader) as MusicTrack2;

                    Console.WriteLine("Track back");
                    Console.WriteLine(trackReaderBack);

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "3":

                    //  JSon exception
                    string invalidJson = "{\"Artist\":\"Rob\",\"Title}";
                    try
                    {
                        MusicTrack trackRead3 = JsonConvert.DeserializeObject<MusicTrack>(invalidJson);
                    }
                    catch (JsonException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("finishing json exception");
                    Console.ReadKey();
                    return true;

                case "4":

                    string input = "Rob Mary David Jenny Chris Imogen";

                    string regularExpressionToMatch = " ";
                    string patternToReplace = ",";

                    // USING System.Text.RegularExpression
                    string replaced = Regex.Replace(input, regularExpressionToMatch, patternToReplace);

                    Console.WriteLine(replaced);

                    Console.WriteLine("finishing json exception");
                    Console.ReadKey();
                    return true;

                case "5":

                    string input5 = "Rob   Mary David   Jenny Chris Imogen";

                    string regularExpressionToMatch5 = "  +";  // 2 spaces -> Rob, Mary David, Jenny Chriss Imogen
                    string patternToReplace5 = ",";

                    // USING System.Text.RegularExpression
                    string replaced5 = Regex.Replace(input5, regularExpressionToMatch5, patternToReplace5);
                    Console.WriteLine(input5);
                    Console.WriteLine(replaced5);

                    Console.WriteLine("finishing json exception");
                    Console.ReadKey();
                    return true;

                case "6":
                    //Validation 
                    string input6 = "Rob Mary:My Way:120";

                    string regToMatch6 = ".+:.+:.+";

                    // . -> match any character
                    // + -> one or more of the previus itm
                    // .+ -> match one or more
                   
                    if (Regex.IsMatch(input6,regToMatch6))
                        Console.WriteLine("Valid");

                    Console.WriteLine("finishing Validation Regex");
                    Console.ReadKey();
                    return true;
                case "7":
                    //Validation numbers
                    string input7 = "Rob Mary:My Way:pp";

                    string regToMatch7 = @".+:.+:[0-9]+$";
                    // [0-9] -> match any digit
                    // [0-9]+ -> match ONE or More Digits
                    // $  -> anchor this character at the end of the string
                    //@ -> process as VERVATIM STRING
                    // . -> match any character
                    // + -> one or more of the previus itm
                    // .+ -> match one or more

                    if (Regex.IsMatch(input7, regToMatch7))
                        Console.WriteLine("Valid");
                    else
                        Console.WriteLine("NOT Valid");

                    Console.WriteLine("finishing Validation Regex");
                    Console.ReadKey();
                    return true;

                case "8":
                    //Perfect Validation
                    string input8 = "RobMary:MyWay:120";

                    string regToMatch8 = @"^([a-z]|[A-Z]|)+:([a-z]|[A-Z]|)+:[0-9]+$";
                    // ^ the start of line
                    // | -> OR
                    //
                    // [0-9] -> match any digit
                    // [0-9]+ -> match ONE or More Digits
                    // $  -> anchor this character at the end of the string
                    //@ -> process as VERVATIM STRING
                    // . -> match any character
                    // + -> one or more of the previus itm
                    // .+ -> match one or more

                    if (Regex.IsMatch(input8, regToMatch8, RegexOptions.IgnorePatternWhitespace))
                        Console.WriteLine("Valid");
                    else
                        Console.WriteLine("NOT Valid");

                    Console.WriteLine("finishing Perfect Validation");
                    Console.ReadKey();
                    return true;

                case "9":
                    //Regex basic

                    Console.WriteLine(Regex.Match("color", @"colo8?h?-?r").Success);
                    Console.WriteLine(Regex.Match("colour", @"colou?r").Success);
                    Console.WriteLine(Regex.Match("colouur", @"colou?r").Success);

                    Match m = Regex.Match("Any color you like", @"col");
                    Console.WriteLine(m.Value);

                    Match m2 = Regex.Match("Any color you like, there are two colors", @"col");
                    Console.WriteLine(m2.Value);
                    Match m3 = m2.NextMatch();
                    Console.WriteLine(m3.Value);

                    foreach (Match match in Regex.Matches("Any color you like, there are two colors", @"col"))
                    {
                        Console.WriteLine(match.Value);
                    }

                    // | alternator
                    Console.WriteLine(Regex.IsMatch("Jenny", "Jen(ny|nifer)"));


                    Console.WriteLine("finishing regex basic");
                    Console.ReadKey();
                    return true;

                case "10":
                    //Regex Compile

                    Regex r = new Regex(@"sausaguex?", RegexOptions.Compiled);
                    Console.WriteLine(r.Match("sausague"));
                    Console.WriteLine(r.Match("sausagues").Value);

                    Console.WriteLine("finishing regex Compile");
                    Console.ReadKey();
                    return true;
                case "11":
                    //Regex Options
                    Console.WriteLine(Regex.Match("a", "A", RegexOptions.IgnoreCase));
                    Console.WriteLine(Regex.Match("AAAa", "(?i)a(?-i)a", RegexOptions.IgnoreCase));
                    Console.WriteLine(Regex.Match("AAAa", "(?i)Aaa", RegexOptions.IgnoreCase));

                    // ??
                    Console.WriteLine(Regex.Match("AAAa", "(?-i)aaa", RegexOptions.IgnoreCase)); // ??


                    Console.WriteLine("finishing regex optrions");
                    Console.ReadKey();
                    return true;

                case "12":
                    //Escapes
                    //metacharactes
                    //  \*+?|{[()^$.#

                    // prefix with a backslash
                    Console.WriteLine(Regex.Match("what?", @"what\?")); // correct returns what?
                    Console.WriteLine(Regex.Match("what?", @"what?"));  //return what -> incorrect , ? is missing

                    Console.WriteLine("finishing regex Compile");
                    Console.ReadKey();
                    return true;

                case "13":
                    //Character Set

                    Console.WriteLine(Regex.Matches("That is that.", "[Tt]hat").Count);
                    Console.WriteLine(Regex.Match("That is that.", "[Th]at"));

                    Console.WriteLine(Regex.Match("ftyuiz qperty lm", @"f[^aeiou]"));
                    Console.WriteLine(Regex.Match("b1-c4", @"[a-h]\d-[a-h]\d"));

                    Console.WriteLine("finishing regex Compile");
                    Console.ReadKey();
                    return true;

                case "14":
                    //Quantifiers

                    Console.WriteLine(Regex.Match("cv15.doc", @"cv\d*\.doc"));
                    Console.WriteLine(Regex.Match("cv15t.doc", @"cv\d*t"));

                    //anything beetween cv and .doc
                    Console.WriteLine(Regex.Match("cvjoint.doc", @"cv.*\.doc"));
                    Console.WriteLine(Regex.Match("cvjoint.doc", @"cv.*.doc"));
                    Console.WriteLine(Regex.Match("cvjoint99ydoc", @"cv.*ydoc"));

                    Console.WriteLine(Regex.Match("cvjoint99ydoc", @"cv.*pc"));

                    //quantitie matchs one or more times

                    Console.WriteLine(Regex.Matches("slow  yeah slooow", @"slo+w").Count);

                    Console.WriteLine("finishing regex Compile");
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


     //JSON 
    class MusicTrack 
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Lenght { get; set; }

       

        //string that overrides the behavior in the base class
        public override string ToString()
        {
            return Artist + " " + Title + " " + Lenght.ToString() + "seconds long";
        }

        public MusicTrack(string artist, string title, int lenght)
        {
            Artist = artist;
            Title = title;
            Lenght = lenght;
        }
    }

    //xml PARAMETLESS
   public  class MusicTrack2 // PARAMETLESS CONSTRUCTOR 
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Lenght { get; set; }



        ////string that overrides the behavior in the base class
        //public override string ToString()
        //{
        //    return Artist + " " + Title + " " + Lenght.ToString() + "seconds long";
        //}

       
    }

}
