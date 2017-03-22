using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fileHandling
{
    class FileReadStrings
    {
        static void Main()
        {
            // read first record from a file
            FileStream people = new FileStream("messages.txt", FileMode.Open,   FileAccess.Read);
                StreamReader inputStream = new StreamReader(people);

            string lineIn;

            lineIn = inputStream.ReadLine();
            while (lineIn != null)
            {
                Console.WriteLine(lineIn);
                lineIn = inputStream.ReadLine();
            }
                inputStream.Close();

        }
    }
}