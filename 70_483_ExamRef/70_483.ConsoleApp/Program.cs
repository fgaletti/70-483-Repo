using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

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
            Console.WriteLine("1) Consume Xml ");
            Console.WriteLine("2) XmlDocument ");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":

                    using (StringReader stringReader = new StringReader(XMLDocument))
                    {
                        XmlTextReader xmlReader = new XmlTextReader(stringReader);

                        while(xmlReader.Read())
                        {
                            string description = string.Format("Type : {0} Name: {1} Value: {2} ",
                                xmlReader.NodeType.ToString(), xmlReader.Name, xmlReader.Value);

                            Console.WriteLine(description);
                        }
                    }

                        Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;
                case "2":
                    // XmlDocument
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(XMLDocument);

                    XmlElement rootElement = doc.DocumentElement;
                    //make sure it is the right element
                    if (rootElement.Name != "MusicTrack")
                    {
                        Console.WriteLine("not a music track");
                    }
                    else
                    {
                        string artist = rootElement["Artist"].FirstChild.Value;
                        Console.WriteLine("", artist);
                        string title = rootElement["Title"].FirstChild.Value;
                        Console.WriteLine("Artist: {0} , Title: {1} ", artist, title );
                    }

                    Console.WriteLine("finishing XmlDocument");
                    Console.ReadKey();
                    return true;
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

       static string XMLDocument = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                "<MusicTrack xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  " +
                "<Artist>Rob Miles</Artist>  " +
                "<Title>My Way</Title>  " +
                "<Length>150</Length>" +
                "</MusicTrack>";
    }
}
