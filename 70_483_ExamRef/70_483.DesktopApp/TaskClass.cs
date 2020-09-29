using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_483.DesktopApp
{
    class TaskClass
    {
       public static double ComputeAverages(long noOfValues)
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
