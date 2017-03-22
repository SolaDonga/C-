using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array3
{
    class Program
    {
        static int[,] studentResult = new int[3, 3];
       // static int[,] board = new int[3, 3];
        static void Main(string[] args)
        {
          
            FillArray();
           
        }
        static void FillArray()
        {
           
            for (int row = 0; row <3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write("Enter Result:");
                   studentResult [row, col] = int.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
           
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    
                    Console.Write(studentResult [row,col]+" ");
                    
                }
              
                Console.WriteLine("");
            }
        }
    }
}
