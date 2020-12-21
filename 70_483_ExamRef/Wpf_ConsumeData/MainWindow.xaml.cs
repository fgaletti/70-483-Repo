using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_ConsumeData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async  void  LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                ImageOfDay imageOfDay = await GetImageOfTheDay("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date=2018-05-29");

                if (imageOfDay.media_type != "image")
                {
                    MessageBox.Show("Not an image");
                }
                else
                {
                    lblDescription.Content = imageOfDay.explanation;
                    await displayUrl(imageOfDay.url);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        async Task<ImageOfDay> GetImageOfTheDay(string imageUrl)
        {
            string nasaJson = await readWebpage(imageUrl);

            ImageOfDay result = JsonConvert.DeserializeObject<ImageOfDay>(nasaJson);
            return result;
        }

        async Task<string> readWebpage(string uri)
        {
            WebClient client = new WebClient();
            return await client.DownloadStringTaskAsync(uri);
        }

        public class ImageOfDay
        {
            public string date { get; set; }
            public string explanation { get; set; }
            public string hdurl { get; set; }
            public string media_type { get; set; }
            public string service_version { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }

        public async Task displayUrl(string url)
        {
            WebClient c = new WebClient();
            byte[] imageBytes = await c.DownloadDataTaskAsync(url);
            MemoryStream imageMemoryStream = new MemoryStream(imageBytes);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = imageMemoryStream;
            bitmapImage.EndInit();
            imgNasa.Source = bitmapImage;
        }

    }
}
