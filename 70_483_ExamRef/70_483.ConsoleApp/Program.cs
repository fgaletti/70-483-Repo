using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
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
            Console.WriteLine("1)  Serialize");
            Console.WriteLine("2)  DeSerialize");
            Console.WriteLine("3)  Custom Serializable");
            Console.WriteLine("4)  DataContract");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":
                    //Serialize
                    MusicDataStore musicData =  MusicDataStore.TestData();
                 //   MusicDataStore musicData = new MusicDataStore();

                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream("musicTracks.bin", FileMode.OpenOrCreate,
                                             FileAccess.Write))
                    {
                        formatter.Serialize(fileStream, musicData);
                    }

                        Console.WriteLine("finishing Serialize");
                    Console.ReadKey();
                    return true;

                case "2":
                    //DeSerialize
                    MusicDataStore inputData;
                    BinaryFormatter formatter2 = new BinaryFormatter();

                    using (FileStream readStream = new FileStream("musicTracks.bin", FileMode.Open,
                                                 FileAccess.Read))
                    {
                        inputData = (MusicDataStore)formatter2.Deserialize(readStream);
                    }

                        Console.WriteLine("finishing DeSerialize");
                    Console.ReadKey();
                    return true;

                case "3":
                    //Custom Serialize
                    ArtistCustom artist3 = new ArtistCustom()
                    {  Name ="Francisco" } ;


                    BinaryFormatter formatter3 = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream("ArtistCustom.bin", FileMode.OpenOrCreate,
                                             FileAccess.Write))
                    {
                        formatter3.Serialize(fileStream, artist3);
                    }

                    Console.WriteLine("finishing Custom Serialize");
                    Console.ReadKey();
                    return true;

                case "4":
                    //Data Contract

                    MusicDataStoreData musicData4 = MusicDataStoreData.TestData();

                    DataContractSerializer formatter4 = new DataContractSerializer(typeof(MusicDataStoreData));

                    using (FileStream outputStream = new FileStream("musictrack.xml", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        formatter4.WriteObject(outputStream, musicData4);
                    }


                    //Read
                    MusicDataStoreData inputData4;

                    using (FileStream inputStream = new FileStream("musictrack.xml", FileMode.Open,
                                                    FileAccess.Read))
                    {
                        //use formatter 
                        inputData4 = (MusicDataStoreData)formatter4.ReadObject(inputStream);   
                    }

                        Console.WriteLine("finishing Custom Serialize");
                    Console.ReadKey();
                    return true;

                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }
        [Serializable]
        class Artist
        {
            public string Name { get; set; }
            [NonSerialized]
            int TempData;
        }

        [Serializable]
        class MusicTrack
        {
            public Artist Artist { get; set; }
            public string Title { get; set; }
            public int Length { get; set; }
        }

        [Serializable]
        class MusicDataStore
        {
            List<Artist> artists = new List<Artist>();
            List<MusicTrack> musicTracks = new List<MusicTrack>();

            public static MusicDataStore TestData()
            {
                MusicDataStore result = new MusicDataStore();
                return result;
            }
        }

        //using system.runtime Serialization
        [Serializable]
        class ArtistCustom : ISerializable
        {
            public string Name { get; set; }

            public ArtistCustom(SerializationInfo info, StreamingContext context)
            {
                Name = info.GetString("name");
            }
            public ArtistCustom()
            {

            }
            [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("name", Name);
            }
        }

        // Add System.Runtime.Serialization 
        [DataContract]
        public class ArtistData
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Name { get; set; }
        }
        [DataContract]
        public class MusicTrackData
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int ArtistID { get; set; }
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public int Length { get; set; }
        }

        //DataContract

        [DataContract]
        public class MusicDataStoreData
        {
            [DataMember]
            public List<ArtistData> ArtistDataList = new List<ArtistData>();
            [DataMember]
            public List<MusicTrackData> MusicTracksDataList = new List<MusicTrackData>();

            public static MusicDataStoreData TestData()
            {
                MusicDataStoreData result = new MusicDataStoreData();

                string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
                string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

                Random rand = new Random(1);
                int IDcount = 0;

                foreach (string artistName in artistNames)
                {
                    ArtistData newArtist = new ArtistData { ID = IDcount++, Name = artistName };
                    result.ArtistDataList.Add(newArtist);
                    foreach (string titleName in titleNames)
                    {
                        MusicTrackData newTrack = new MusicTrackData
                        {
                            ID = IDcount++,
                            ArtistID = newArtist.ID,
                            Title = titleName,
                            Length = rand.Next(20, 600)
                        };
                        result.MusicTracksDataList.Add(newTrack);
                    }
                }
                return result;
            }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                var artistTracks = from artist in ArtistDataList
                                   join track in MusicTracksDataList on artist.ID equals track.ArtistID
                                   select new
                                   {
                                       ArtistName = artist.Name,
                                       track.Title
                                   };

                foreach (var track in artistTracks)
                {
                    result.AppendFormat("Artist:{0} Title:{1}\n", track.ArtistName, track.Title);
                }

                return result.ToString();
            }
        }

    }
}
