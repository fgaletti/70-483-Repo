using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            Console.WriteLine("1) Use FileStream  ");
            Console.WriteLine("2) IDispose FileStream  ");
            Console.WriteLine("3) Work with Text Files StreamWriter  ");
            Console.WriteLine("4) Chain Stream Together  ");
            Console.WriteLine("5 ) File Class  ");
            Console.WriteLine("6 ) Handle Exceptions ");
            Console.WriteLine("7 ) Driver Info ");
            Console.WriteLine("8 ) File Info ");
            Console.WriteLine("9 ) Directory  ");
            Console.WriteLine("10 ) Directory Info ");
            Console.WriteLine("11 ) Using Path");
            Console.WriteLine("12 ) Find Files");

            Console.WriteLine("13 ) WebRequest");
            Console.WriteLine("14 ) WebClient");
            Console.WriteLine("15 ) HttpClient");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":
                    //writing to a file

                    FileStream outputStream = new FileStream("output.txt", FileMode.OpenOrCreate,
                                                 FileAccess.Write);

                    string outputMessageString = "Hello world";
                    byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);

                    outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
                    outputStream.Close();

                    // Read file
                    FileStream inputStream = new FileStream("output.txt", FileMode.Open,
                                               FileAccess.Read);

                    long fileLeght = inputStream.Length;
                    byte[] readBytes = new byte[fileLeght];
                    inputStream.Read(readBytes, 0, (int)fileLeght); //cast to int
                    string readString = Encoding.UTF8.GetString(readBytes);
                    inputStream.Close();
                    Console.WriteLine("Read message: {0}", readString);


                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;
                case "2":
                    //IDispose

                    using (FileStream outputStream2 = new FileStream("output2.txt", FileMode.OpenOrCreate,
                                                        FileAccess.Write ))
                    {
                        string messageString = "Hello world 2";
                        byte[] messageBytes2 = Encoding.UTF8.GetBytes(messageString);
                        outputStream2.Write(messageBytes2, 0, messageBytes2.Length);
                    }

                        Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "3":
                    //StreamWriter

                    using (StreamWriter writeStream = new StreamWriter("outputStream.txt"))
                    {
                        writeStream.Write("Hello Streamwritrer");
                    }

                    //Read
                    using (StreamReader stReader = new StreamReader("outputStream.txt"))
                    {
                        string readString3 = stReader.ReadToEnd();
                        Console.WriteLine("Read string : {0}", readString3);
                    }


                        Console.WriteLine("finishing StreamWriter");
                    Console.ReadKey();
                    return true;

                case "4":
                    //Chain Stream together

                    //1. FileStream
                    //2. GZipStream
                    //3. Stream

                    using (FileStream writeFile = new FileStream("comptext.zip", FileMode.OpenOrCreate,
                                                   FileAccess.Write))
                    {
                        using (GZipStream writeZip = new GZipStream(writeFile, CompressionMode.Compress))
                        {
                            using (StreamWriter stWriter4 = new StreamWriter(writeZip))
                            {
                                stWriter4.Write("Hello Zip File");
                            }
                        }
                    }

                    //Read

                    using (FileStream readfile = new FileStream("comptext.zip", FileMode.Open,
                                                    FileAccess.Read))
                    {

                        using (GZipStream readZip = new GZipStream(readfile, CompressionMode.Decompress))
                        {
                            using (StreamReader sReader = new StreamReader(readZip))
                            {
                                string strDecompress = sReader.ReadToEnd();
                                Console.WriteLine("Decompress: {0}", strDecompress);
                            }
                        }
                    } 

                        Console.WriteLine("finishing Chain Stream together");
                    Console.ReadKey();
                    return true;

                case "5":
                    //FILE class

                    File.WriteAllText(path: "file.txt", contents: "this is File object");
                    File.AppendAllText("file.txt", "This goes on the end");

                    if (File.Exists("file.txt"))
                        Console.WriteLine("File Exists");

                    string contents = File.ReadAllText("file.txt");
                    Console.WriteLine("File contenct :{0}", contents);

                    File.Copy("file.txt", "copyfile.txt", true); //Exception is exists, use override = true

                    using (TextReader tReader = File.OpenText("file.txt"))
                    {
                        Console.WriteLine("Using TextReader: {0}", tReader.ReadToEnd());
                    }

                    //using stream reader
                    using (StreamReader tReader = File.OpenText("file.txt"))
                    {
                        Console.WriteLine("Using StreamReader: {0} ", tReader.ReadToEnd() );
                    }


                    Console.WriteLine("finishing file class");
                    Console.ReadKey();
                    return true;

                case "6":
                    //Handle Exceptions

                    try
                    {
                        string contents6 = File.ReadAllText("testfile.txt"); //does not exists
                    }
                    catch (FileNotFoundException notFoundEx)
                    {
                        //File not found
                        Console.WriteLine(notFoundEx.Message);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    Console.WriteLine("finishing Handle Exceptions");
                    Console.ReadKey();
                    return true;
                case "7":
                    //Driver Info

                    DriveInfo[] drivers = DriveInfo.GetDrives();

                    foreach (DriveInfo drive in drivers)
                    {
                        Console.WriteLine("Name: {0}", drive);
                        if (drive.IsReady)
                        {
                            Console.WriteLine("Type: {0}", drive.DriveType);
                            Console.WriteLine("Format : {0}", drive.DriveFormat);
                            Console.WriteLine("Free Space: {0}", drive.TotalFreeSpace);
                        }
                        else
                        {
                            Console.WriteLine("Driver is no ready");
                        }

                    }

                    Console.WriteLine("finishing Driver Info");
                    Console.ReadKey();
                    return true;
                case "8":
                    //File Info

                    string filePath = "textFile.txt";

                    File.WriteAllText(filePath, "This goes here");

                    FileInfo info = new FileInfo(filePath); //NEW FILE INFO

                    Console.WriteLine("Name:{0}", info.Name);
                    Console.WriteLine("Full Path:{0}", info.FullName);
                    Console.WriteLine("Last Access:{0}", info.LastAccessTime);
                    Console.WriteLine("Lenght:{0}", info.Length);
                    Console.WriteLine("Attributes:{0}", info.Attributes);

                    Console.WriteLine("Make the file READoNLY");

                    info.Attributes |= FileAttributes.ReadOnly;  //ReadOnly

                    Console.WriteLine("Attributes:{0}", info.Attributes);

                    Console.WriteLine("Remove the readonly attribute");

                    info.Attributes &= ~FileAttributes.ReadOnly; //Remove Readnloy
                    Console.WriteLine("Attributes:{0}", info.Attributes);


                    Console.WriteLine("finishing File Info");
                    Console.ReadKey();
                    return true;

                case "9":
                    //Directory 

                    Directory.CreateDirectory("TestDir");

                    if (Directory.Exists("Testdir"))
                        Console.WriteLine("Directory created");

                    Directory.Delete("TestDir");
                    Console.WriteLine("Directory deleted");

                    Console.WriteLine("finishing Directory ");
                    Console.ReadKey();
                    return true;

                case "10":
                    //Directory Info -- SAME funcitonality like directory 

                    DirectoryInfo localDir = new DirectoryInfo("TestDir");
                    localDir.Create();

                    if(localDir.Exists)
                        Console.WriteLine("Directory created");

                    localDir.Delete();
                    Console.WriteLine("Directory deleted INFO");

                    Console.WriteLine("finishing Directory Info");
                    Console.ReadKey();
                    return true;

                case "11":
                    //Path 


                    string fullname = @"c:\users\rob\document\textpath.txt";

                    string dirName = Path.GetDirectoryName(fullname);
                    string fileName = Path.GetFileName(fullname);
                    string fileExtension = Path.GetExtension(fullname);
                    string lisName = Path.ChangeExtension(fullname, ".lis");
                    string newTest = Path.Combine(dirName, "textpath.txt"); //use dirname to create a File

                    Console.WriteLine("Extension :{0}", fileExtension);
                    Console.WriteLine("Lis name: {0}", lisName);
                    Console.WriteLine("NewText: {0}", newTest );

                    Console.WriteLine("finishing Path ");
                    Console.ReadKey();
                    return true;

                case "12":
                    //Searching Files 

                    DirectoryInfo startDir = new DirectoryInfo(@"..\..\..\..");
                    string searchString = "*.cs";

                    FindFiles(startDir, searchString);

                    Console.WriteLine("finishing Searching Files ");
                    Console.ReadKey();
                    return true;
                case "13":
                    //WebRequest 

                    WebRequest webRequest = WebRequest.Create("http://www.microsoft.com");
                    WebResponse response = webRequest.GetResponse();

                    using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                    {
                        string siteText = responseReader.ReadToEnd();
                        Console.WriteLine(siteText);
                    }


                        Console.WriteLine("finishing WebRequest ");
                    Console.ReadKey();
                    return true;

                case "14":
                    //WebClient 

                    WebClient webClient = new WebClient();
                    string siteText14 = webClient.DownloadString("http://www.microsoft.com");
                    Console.WriteLine(siteText14);

                    Console.WriteLine("finishing WebClient ");
                    Console.ReadKey();
                    return true;
                
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }

          
                
        }


        //Searching Files 326
        static void FindFiles(DirectoryInfo dir , string searchPattern)
        {
            foreach(DirectoryInfo directory in dir.GetDirectories())
            {
                FindFiles(directory, searchPattern);
            }

            FileInfo[] matchingFiles = dir.GetFiles(searchPattern);
            foreach (FileInfo fileInfo in matchingFiles)
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }

        //webClient async
        async Task<string> readWebPage(string url)
        {
            WebClient webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }

        //HTTPCLIENT
        // System.Net.Http
       static  async Task<string> readWebPageClient(string url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }

    }


}
