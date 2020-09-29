using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace _70_483.DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void btnStartAverage_Click(object sender, EventArgs e)
        {
            long noOfValues = long.Parse(txtRandom.Text);

            Task.Run(() =>
           {
               // error same thread -> lblAverage.Text = "Result: " + ComputeAverages(noOfValues);
               double result = ComputeAverages(noOfValues);

               lblAverage.Dispatcher.
           });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

    }
  
}
