using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
            Console.WriteLine("1) Musick track classes List, Liq Operator, Progression, anonymous");
            Console.WriteLine("2) Linq GROUP");
            Console.WriteLine("3) Method Base ");
            Console.WriteLine("4) Sample Xml");
            Console.WriteLine("5) Created Xml Linq");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":

                    string[] artistNames = new string[] { "Rob", "Fred", "Bloofs", "Immy" };
                    string[] titleNames = new string[] { "My way", "Your way", " His way" };

                    List<Artist> artistsList = new List<Artist>();
                    List<MusicTrack> musicTracksList = new List<MusicTrack>();

                    Random rand = new Random(1);

                    foreach (string artist in artistNames)
                    {
                        Artist artistObj = new Artist() { Name = artist };

                        foreach (string title in titleNames)
                        {
                            //Object inizializer
                            MusicTrack newTrack = new MusicTrack()
                            {
                                Artist = artistObj,
                                Title = title,
                                Length = rand.Next(1, 60)
                            };
                            musicTracksList.Add(newTrack);
                        }
                    }

                    //read
                    foreach (MusicTrack track in musicTracksList)
                    {
                        Console.WriteLine("Artist : {0} Title:{1} Lenght: {2}",
                               track.Artist.Name , track.Title, track.Length );
                    }



                    //LINQ 
                    IEnumerable<MusicTrack> selectedTracks =
                             from track in musicTracksList
                             where track.Length == 15
                             select track;

                    foreach(MusicTrack track in selectedTracks)
                    {
                        Console.WriteLine("track linq: {0}", track.Title);  
                    }

                    //PROGRESSIONS
                    var selectedTracksPro = from track in musicTracksList
                                            where track.Length == 15
                                            select new TrackDetails
                                            {
                                                ArtistName = track.Artist.Name,
                                                Title = track.Title
                                            };

                    foreach (TrackDetails details in selectedTracksPro)
                    {
                        Console.WriteLine("progression, ArtistName: {0} Title:{1}", 
                                    details.ArtistName, details.Title);
                    }

                    
                    //Anonymous Type

                    var selectedAnonyTracks = from track in musicTracksList
                                              where track.Length == 15
                                              select new
                                              {
                                                  Nombre = track.Artist.Name,
                                                  Titulo = track.Title
                                              };

                    foreach(var a in selectedAnonyTracks)
                    {
                        Console.WriteLine("Nombre: {0} Titulo: {1}", a.Nombre, a.Titulo);
                    }

                       


                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":

                    //fillout data
                    string[] artistNames2 = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
                    string[] titleNames2 = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

                    List<ArtistJoin> artistsList2 = new List<ArtistJoin>();
                    List<MusicTrackJoin> musicTracksLists2 = new List<MusicTrackJoin>();

                    Random rand2 = new Random(1);
                    int IDcount = 0;

                    foreach (string artistName in artistNames2)
                    {
                        ArtistJoin newArtist = new ArtistJoin { ID = IDcount++, Name = artistName };
                        artistsList2.Add(newArtist);
                        foreach (string titleName in titleNames2)
                        {
                            MusicTrackJoin newTrack = new MusicTrackJoin
                            {
                                ID = IDcount++,
                                ArtistID = newArtist.ID,
                                Title = titleName,
                                Length = rand2.Next(20, 600)
                            };
                            musicTracksLists2.Add(newTrack);
                        }
                    }
                    // end fill out
                    //Group By

                    var artistSummary = from track in musicTracksLists2
                                        group track by track.ArtistID
                                        into artistTrackSummary
                                        select new
                                        {
                                            ID = artistTrackSummary.Key,
                                            Count = artistTrackSummary.Count()
                                        };

                    foreach (var item in artistSummary)
                    {
                        Console.WriteLine("Artist: {0} Total: {1}", item.ID, item.Count);
                    }

                    //Union Group By Name
                    var artistSummaryName = from track in musicTracksLists2
                                            join artist2 in artistsList2 on
                                            track.ArtistID equals artist2.ID
                                            group track by artist2.Name // Key
                                            into artistTrackSummary
                                            select new
                                            {
                                                ID = artistTrackSummary.Key, //Name 
                                                Count = artistTrackSummary.Count()
                                            };

                    Console.WriteLine();
                    Console.WriteLine("Group Name:");

                    foreach (var item in artistSummaryName)
                    {
                        Console.WriteLine("Artist: {0} Total: {1}", item.ID, item.Count);
                    }

                    //TAKE AND SKIP

                    Console.WriteLine();
                    Console.WriteLine("Skip");

                    int pageNo = 0;
                    int pageSize = 10;

                    while(true)
                    {
                        //get track information
                        var trackList = from musicTrack in musicTracksLists2.Skip(pageNo * pageSize).Take(pageSize)
                                        join artist3 in artistsList2
                                        on musicTrack.ArtistID equals artist3.ID
                                        select new
                                        {
                                            ArtistName = artist3.Name,
                                            musicTrack.Title
                                        };

                        // quit if we reach the end of the data
                        if (trackList.Count() == 0)
                            break;

                        //Display the query result
                        foreach (var item in trackList)
                        {
                            Console.WriteLine("Artist: {0} Title:{1}" , item.ArtistName, item.Title);
                        }

                        Console.WriteLine("Press any key to contonue");
                        Console.ReadKey();

                        //move to the next
                        pageNo++;

                    }

                    // Agreggate Sum
                    Console.WriteLine();
                    Console.WriteLine("Sum");

                    var artistSummarySum = from track in musicTracksLists2
                                           join artist2 in artistsList2 on
                                           track.ArtistID equals artist2.ID
                                           group track by artist2.Name
                                           into artistTrackSummary
                                           select new
                                           {
                                               ID = artistTrackSummary.Key,
                                               Lenght = artistTrackSummary.Sum( x => x.Length)
                                           };

                    foreach (var item in artistSummarySum)
                    {
                        Console.WriteLine("Name: {0} Total {1} ", item.ID, item.Lenght);
                    }


                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "3":
                    //method base
                    //fillout data
                    string[] artistNames3 = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
                    string[] titleNames3= new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

                    List<ArtistJoin> artistsList3 = new List<ArtistJoin>();
                    List<MusicTrackJoin> musicTracksLists3 = new List<MusicTrackJoin>();

                    Random rand3 = new Random(1);
                    int IDcount3 = 0;

                    foreach (string artistName in artistNames3)
                    {
                        ArtistJoin newArtist = new ArtistJoin { ID = IDcount3++, Name = artistName };
                        artistsList3.Add(newArtist);
                        foreach (string titleName in titleNames3)
                        {
                            MusicTrackJoin newTrack = new MusicTrackJoin
                            {
                                ID = IDcount3++,
                                ArtistID = newArtist.ID,
                                Title = titleName,
                                Length =  rand3.Next(20, 600) // change to 1 to test Sum 
                            };
                            musicTracksLists3.Add(newTrack);
                        }
                    }
                    // end fill out

                    var artistSummary3 = musicTracksLists3.Join(
                           artistsList3, //inner
                           track => track.ArtistID, // outter Key Selector
                           artist => artist.ID, // inner Key selector
                           (track, artist) => // result
                             new
                             {
                                 track = track,
                                 artist = artist
                             }
                            )
                            .GroupBy(
                             temp0 => temp0.artist.Name,
                             temp0 => temp0.track
                           )
                           .Select(
                           artistTrackSummary3 =>
                              new
                              {
                                  ID = artistTrackSummary3.Key,
                                  Length = artistTrackSummary3.Sum(x => x.Length)
                              }
                        );

                    foreach (var item in artistSummary3)
                    {
                        Console.WriteLine("Artist: {0} Tracks: {1}", item.ID, item.Length);
                    }

                    Console.WriteLine("finishing method base");
                    Console.ReadKey();
                    return true;

                case "4":
                    //Read Xml Linq
                    string XmlText = "" +
                        " <MusicTracks> " +
                            "<MusicTrack> " +
                                "<Artist>Rob Miles</Artist> " +
                                "<Title>My Way </Title> " +
                                "<Length>150</Length>" +
                            "</MusicTrack>" +

                             "<MusicTrack> " +
                                "<Artist> Immi</Artist> " +
                                "<Title>Her Way </Title> " +
                                "<Length>200</Length>" +
                            "</MusicTrack>" +
                    "</MusicTracks> ";

                    //System.Xml.Liq
                    XDocument musicTrackDocument = XDocument.Parse(XmlText);

                    IEnumerable<XElement> selectedTracksXml = from track in
                                                         musicTrackDocument.Descendants("MusicTrack")
                                                           select track;

                    foreach (XElement item in selectedTracksXml)
                    {
                        Console.WriteLine("Artist: {0} Title: {1}",
                                       item.Element("Artist").FirstNode,
                                       item.Element("Title").FirstNode);
                    }
                    // -------------------------

                    //FILTER XML
                    Console.WriteLine();
                    Console.WriteLine("Filter XML");

                    IEnumerable<XElement> selTrackFilter =
                        from track in musicTrackDocument.Descendants("MusicTrack")
                        where (string)track.Element("Artist") == "Rob Miles"
                        select track;

                    foreach (XElement item in selTrackFilter)
                    {
                        Console.WriteLine("Artist: {0} Title: {1}",
                                       item.Element("Artist").FirstNode,
                                       item.Element("Title").FirstNode);
                    }
                    //-----------------------------

                    // METHOD BASE LINQ-XML
                    //FILTER XML
                    Console.WriteLine();
                    Console.WriteLine("Method-base XML");
                    IEnumerable<XElement> selectedMethodXml = musicTrackDocument.Descendants("MusicTrack")
                                                .Where(element => (string)element.Element("Artist") == "Rob Miles");

                    foreach (XElement item in selTrackFilter)
                    {
                        Console.WriteLine("Artist: {0} Title: {1}",
                                       item.Element("Artist").FirstNode,
                                       item.Element("Title").FirstNode);
                    }
                    //--------------------------------

                    Console.WriteLine("finishing Read Xml Linq");
                    Console.ReadKey();
                    return true;

                case "5":
                    //Create XML with LINQ

                    XElement musicTracksCreated = new XElement("MusicTracks",
                          new List<XElement>
                          {
                              new XElement("MusicTrack",
                                new XElement("Artist", "Rob Miles"),
                                new XElement("Title", "my Way")),
                              new XElement("MusicTrack",
                                 new XElement("Artist", "Immy"),
                                 new XElement("Title", "Her Way"))
                          }
                        );

                    IEnumerable<XElement> seletedToModify = from trackModif in musicTracksCreated.Descendants("MusicTrack")
                                                            where (string)trackModif.Element("Title") == "my Way"
                                                            select trackModif;//.Element("Title");

                    foreach (XElement item in seletedToModify)
                    {
                        item.Element("Title").FirstNode.ReplaceWith("My Wayy");
                    }

                    //Add New ELEMENT
                    IEnumerable<XElement> selectedNew = from trackNew in musicTracksCreated.Descendants("MusicTrack")
                                                        where trackNew.Element("Style") == null
                                                        select trackNew;

                    foreach (XElement item in selectedNew)
                    {
                        item.Add(new XElement("Style", "Rock"));
                    }

                    Console.WriteLine(musicTracksCreated.ToString());

                    Console.WriteLine("finishing Create XML with LINQ");
                    Console.ReadKey();
                    return true;
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

        class Artist
        {
            public string Name { get; set; }
        }

        class MusicTrack
        {
            public Artist Artist { get; set; }
            public string Title { get; set; }
            public int Length { get; set; }
        }

        // Linq progression

        class TrackDetails
        {
            public string ArtistName;
            public string Title;
        }


        //Join

        class ArtistJoin
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        class MusicTrackJoin
        {
            public int ID { get; set; }
            public int ArtistID { get; set; }
            public string Title { get; set; }
            public int Length { get; set; }
        }

    }
}
