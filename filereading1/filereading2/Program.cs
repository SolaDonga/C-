using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace filereading2
{
    public class Program
    {
       
        static int[] count = new int[5];
        static int[] nonIrish = new int[5];
        static int[] irish = new int[5];
        static int[] sales = new int[2];
        static bool startProgram = true;
        static void Main(string[] args)
        {
            
            while (startProgram)
            {
                Menu();
            }
        }
        static void Menu()
        {
            int selection = 0;
            Console.WriteLine("\nMenu\n\n1. Sales Person Report\n2. Sales Report\n3. Search for Employee\n4. Exit");
            Console.Write("Select option: ");
            int.TryParse(Console.ReadLine(),out selection);
            ///This menu brings the user to the correct areas in the program.
            switch (selection)
            {
                case 1:
                    Console.Clear();
                    Print();
                    Console.ReadLine();
                    Console.Clear();
                    return;
                case 2:
                    Console.Clear();
                    Report();
                    Console.ReadLine();
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Search();
                    Console.ReadLine();
                    Console.Clear();
                    return;
                case 4:
                    startProgram = false;
                    break;
                default:
                    Console.Clear();
                    break;
            }


        }
        static void Print()
        {
            string lineIn, starRating;
            string[] fields = new string[3];
            string[] names = new string[3];
            int[] sales = new int[3];
            int count = 0;
            string bestGuy;
            string tableFormat = "{0,-7}{1,-15}{2,-15}{3,-15}{4,-7}";

            // open connection
            FileStream fs = new FileStream("messages.txt", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);
            // print heading

            Console.WriteLine(tableFormat, "Number", "Name", "Nationality", "Sales", "Rating");

            lineIn = inputStream.ReadLine();

            while (lineIn != null)
            {
                fields = lineIn.Split(',');
                names[count] = fields[1];
                sales[count] = Convert.ToInt32(fields[3]);
                fields[1] = nameSplit(fields[1]);
                starRating = ratingAdd(Convert.ToInt32(fields[3]));
                ///Writes out each line containing data in the correct formats
                Console.WriteLine(tableFormat, fields[0], fields[1], fields[2], Convert.ToInt32(fields[3]), starRating);
                lineIn = inputStream.ReadLine();
                count++;
            }
            bestGuy = salesSort(sales, names);
            Console.WriteLine("\nStandard Deviation: "+ standDev(sales)+"\nTop Seller: "+bestGuy );
            inputStream.Close();
            return;
        }
        static string nameSplit(string nameIn)
        {
            //This splits the employee name so that the first name can be abbreviated
            string[] name = new string[1];
            name = nameIn.Split(' ');
            name[0] = name[0].Substring(0, 1).ToUpper() + ".";
            return String.Join(" ", name);

        }
        static string ratingAdd(int ratingIn)
        {
            //This adds the correct star rating for sales made
            string rating;
            int ratingCheck = 0;
            for (int i = 100; i <= ratingIn; i += 100)
            {
                ratingCheck++;
            }
            switch (ratingCheck)
            {
                case 1:
                case 2:
                case 3:
                    rating = "*";
                    break;
                case 4:
                case 5:
                    rating = "**";
                    break;
                case 6:
                    rating = "***";
                    break;
                case 7:
                case 8:
                case 9:
                    rating = "****";
                    break;
                default:
                    rating = "*****";
                    break;
            }
            return rating;

        }

        static void Report()
        {
            string lineIn; 
            string[] fields = new string[3];
            string[] tableTitle = { "Under 400", "400-599", "600-699", "700-999", "1000+" };

            string tableFormat = "{0,-15}{1,-15}{2,-15}{3,-15}";//format table

            // open connection
            FileStream fs = new FileStream("messages.txt", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);
            // print heading

            Console.WriteLine(tableFormat, "Score Total", "Count", "Irish", "Non-Irish");

            lineIn = inputStream.ReadLine();
            while (lineIn != null)
            {
                fields = lineIn.Split(',');
                countCheck(Convert.ToInt32(fields[3]),fields[2]);
               
                lineIn = inputStream.ReadLine();
                
            }
            inputStream.Close();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(tableFormat, tableTitle[i], count[i],nonIrish[i], irish[i]);
            }
            Console.WriteLine(tableFormat,"Total",count.Sum(),nonIrish.Sum(),irish.Sum());//prints combined total of fields above
            return;
           
        }
        static void countCheck(int checkIn,string nationalityIn)
        {
            int check = 0;
            for (int i = 100; i <= checkIn; i += 100)
            {
                check++;
            }
            switch (check)//checks nationality with sales made
            {
                case 1:
                case 2:
                case 3:
                   count[0] += 1;
                    if(nationalityIn.ToLower() == "irish")
                    {
                        irish[0] += 1;
                    }
                    else
                    {
                        nonIrish[0] += 1;
                    }
                    break;
                case 4:
                case 5:
                    count[1] += 1;
                    if (nationalityIn.ToLower() == "irish")
                    {
                        irish[1] += 1;
                    }
                    else
                    {
                        nonIrish[1] += 1;
                    }
                    break;
                case 6:
                    count[2] += 1;
                    if (nationalityIn.ToLower() == "irish")
                    {
                        irish[2] += 1;
                    }
                    else
                    {
                        nonIrish[2] += 1;
                    }
                    break;
                case 7:
                case 8:
                case 9:
                    count[3] += 1;
                    if (nationalityIn.ToLower() == "irish")
                    {
                        irish[3] += 1;
                    }
                    else
                    {
                        nonIrish[3] += 1;
                    }
                    break;
                default:
                    count[4] += 1;
                    if (nationalityIn.ToLower() == "irish")
                    {
                        irish[4] += 1;
                    }
                    else
                    {
                        nonIrish[4] += 1;
                    }
                    break;
            }

        }
        static string fileSearch(string searchTerm)
        {
            string lineIn;
            string[] fields = new string[3];
            // open connection
            FileStream fs = new FileStream("messages.txt", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);
            // print heading

            lineIn = inputStream.ReadLine();

            searchTerm = searchTerm.ToLower();
            while (lineIn != null)
            {
                fields = lineIn.Split(',');
                if (fields[0].ToLower().Contains(searchTerm))//checks search term and returns fields to be split
                {
                    return lineIn;
                }
                lineIn = inputStream.ReadLine();
            }
            inputStream.Close();
            return null;
        }
        static void Search()
        {
            string searchTerm, employee;
            string[] fields = new string[3];
            Console.Write("Enter Employee Number: ");
            searchTerm = Console.ReadLine();
            if (searchTerm != "-999")//sentinal number
            {
                employee = fileSearch(searchTerm);//searches file
                //Display Name if valid search 
                if (employee != null)
                {
                    fields = employee.Split(',');
                    Console.WriteLine("Employee name: " + fields[1]);
                    Console.WriteLine("Sales: " + fields[3]);
                }
                else
                {
                    Console.WriteLine("No match found!");
                    Console.Write("Enter Employee Number(-999 to exit): ");///If no match found at first
                    searchTerm = Console.ReadLine();
                }
            }
            else
            {
                return;
            }
        }
        static double standDev(int[] salesIn)
    {
        ///This gathers the standard deviation for Sales.
        double average = salesIn.Average();
        double sumOfDerivation = 0;
        foreach (double value in salesIn)
        {
            sumOfDerivation += (value) * (value);
        }
        double sumOfDerivationAverage = sumOfDerivation / (salesIn.Length - 1);
        return (Math.Sqrt(sumOfDerivationAverage - (average * average)))/2;
    }
        static string salesSort(int[] sales,string[] names)
        {

            ///This Sorts the Names correctly based on the values of the Sales tab
            Array.Sort(sales,names);
            Array.Reverse(names);
            string[] name = new string[1];
            name = names[0].Split(' ');
            name[0] = name[0].Substring(0, 1).ToUpper() + ".";
            name[1] = name[1].Substring(0, 1).ToUpper() + ".";
            return String.Join(" ", name);
        }
    }
    
}
