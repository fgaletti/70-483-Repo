using System;
using System.Collections.Generic;
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

namespace _70_483.WpfApp
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

        private void BntStartAverage_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(txtRandom.Text);

            Task.Run(() =>
            {
                // error same thread -> lblAverage.Text = "Result: " + ComputeAverages(noOfValues);

                lblAverage.Content = "Result: " + ComputeAverages(noOfValues);

                //double result = ComputeAverages(noOfValues);

                //lblAverage.Dispatcher.Invoke(() =>
                //{
                //    lblAverage.Content = "Result: " + ComputeAverages(noOfValues);
                //}
                //);
           });
        }

        private double ComputeAverages(long noOfValues)
        {
            double total = 0;
            Random ran = new Random();

            for (double values = 0; values < noOfValues; values++)
            {
                total = total + ran.NextDouble();
            }

            return total / noOfValues;
        }

        //async

        private async Task<string> FetchWebPage(string url)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }

        private async void BtnGetUrl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblUrlResult.Content = await FetchWebPage(txtUrl.Text);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // list of pages
        private async Task<IEnumerable<string>> FetchWebPages(string[] urls)
        {
            var tasks = new List<Task<string>>();

            foreach (string url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }

            return await Task.WhenAll(tasks );
        }

        private async void BtnListUrls_Click(object sender, RoutedEventArgs e)
        {
            string[]  arrayUrls = new string[2];

            arrayUrls[0] = "https://www.google.com";
            arrayUrls[1] = "https://www.microsoft.com";

            IEnumerable<string> listUrls = new List<string>();


            listUrls = await FetchWebPages(arrayUrls);
            bool returnToMainThread = true;


        }
    }
}
