using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace WpfWebClasses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int cont = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

         async Task<string> readWebPageClient(string url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://www.microsoft.com";
            txtUrl.Text = await readWebPageClient(url);
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            lblClick.Content = "Click.." + cont++.ToString();
        }

        private async void BtnException_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "http://www.microsoft33.com32323";
                string webText =  await readWebPageClient(url);

            }
            catch (Exception)
            {
                MessageBox.Show("Hello, world!"); 
            }
        }

        async Task WriteBytesAsync(string fileName, byte[] items)
        {
            using (FileStream outStream = new FileStream(fileName, FileMode.OpenOrCreate,
                                 FileAccess.ReadWrite))
            {
                await outStream.WriteAsync(items, 0, items.Length);
            }
        }

        private async void BtnAsync_Click(object sender, RoutedEventArgs e)
        {
            byte[] data = new byte[100];

            data[0] = 7;
            data[56] = 12;
            data[98] = 3;
            try
            {
               await  WriteBytesAsync("demo:.dat", data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
