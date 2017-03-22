using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array5
{
    class Program
    {/*Write a method to return biggest value*/
       static int[] myValue = { 1, 3, 6, 5, 8, 7, 9 };
        static void Main(string[] args)
        {
            
            int answer = GetBigValue(myValue);
            Console.WriteLine(answer);
            int answer2 = GetSmallValue(myValue);
            Console.WriteLine(answer2 );
        }
        static int GetBigValue(int[] myValueIn)
        {
            int result = myValueIn[0];
            for (int i = 0; i < myValueIn .Length; i++)
            {
                if (myValueIn[i] > result)
                result = myValueIn[i];
            }
            return result;
        }
        static int GetSmallValue(int[] myValueIn)
        {
            int result2 = myValue[0];
            for (int i = 0; i < myValue.Length; i++)
            {
                if (myValueIn[i] < result2)
                    result2 = myValueIn[i];
            }
            return result2;
        }
    }
}
