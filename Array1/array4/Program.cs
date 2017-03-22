using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 6, 2, 4, 8, 12 };
            bool sorted = CheckSorted(myArray);
            Console.WriteLine(sorted);
        }
        static bool CheckSorted(int[] myArrayIn)
        {
            bool result = true;
            for (int i = 0; i <myArrayIn.Length-1; i++)
            {
                if(myArrayIn [i] > myArrayIn[i + 1])
                {
                    result = false;
                        break;
                }
            }
            return result;
        }
    }
}
