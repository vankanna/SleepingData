using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                 // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter("data.txt");
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                string file = "data.txt";
                StreamReader sr = new StreamReader(file);
                
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(',');
                    string date = DateTime.Parse(arr[0]).ToString("MMM, dd, yyyy");
                    string[] hours = arr[1].Split('|');
                    int total = 0;
                    int average;
                    foreach (string hour in hours) {
                        total += Int32.Parse(hour);
                    }

                    average = total / 7;

                    //how to print out this part
                    
                    Console.WriteLine("Week of " + date);

                    //Console.WriteLine(arr1[1]);
                    Console.WriteLine("Su Mo Tu WE Th Fr Sa Tot Avg");
                    Console.WriteLine("-- -- -- -- -- -- -- --- ---");

                    Console.Write(String.Join(" ", hours));
                    Console.WriteLine(" " + total + " " + average);
                    //Console.WriteLine($"{arr2[1]}");
                    
                }
                sr.Close();








                /*
                // TODO: parse data file
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                Console.WriteLine(dataDate);
                Console.WriteLine(dataEndDate);
                */
            }
        }
    }
}
