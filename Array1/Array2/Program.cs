using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2
{
    class Program
    {/* write a program that takes an array of ints as a parameter and returns the average of every second element*/
        static void Main(string[] args)
        {
            int[] array = { 2, 4, 5, 7, 8, 10 };
            double answer = GetAvg(array);
            Console.WriteLine(answer );
        }
        static double GetAvg(int [] arrayIn)
        {
            double total = 0;
            int count = 0;
            for (int i = 0; i < arrayIn.Length; i+=5)
            {
                total += arrayIn[i];
                count++;
            }
            double avg = total / count;
            return avg;
        }
    }
}
