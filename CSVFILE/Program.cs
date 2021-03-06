using CSVFILE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace CSVFILE
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string csv_file_path = @"G:\CSVFileCSharp\CSV-Import-to-Database-Csharp\stock_list.csv";
            //string csv_file_path = @"G:\CSVFileCSharp\CSV-Import-to-Database-Csharp\DB.txt";

            string ext = Path.GetExtension(csv_file_path);
            bool fileExist = File.Exists(csv_file_path);

            if (fileExist)
            {
                Console.WriteLine("File exists.");


                if (ext != ".csv")
                {
                    Console.WriteLine("Provide a CSV File");
                }
                else
                {
                    ReadCSV ReadCSV = new ReadCSV();
                    InsertDatatoDB InsertDatatoDB = new InsertDatatoDB();
                    //List<Stock> Stock = ReadCSV.getDataFromCSVFile(csv_file_path);
                    List<Stock> Stock = ReadCSV.getDataFromCSVFile2(csv_file_path);
                    //InsertDatatoDB.insertDatatoDBStock(Stock);
                    // Create new stopwatch
                    //Stopwatch stopwatch = new Stopwatch();

                    //// Begin timing
                    //stopwatch.Start();

                    //System.Threading.Thread.Sleep(500);



                    //// Stop timing
                    //stopwatch.Stop();

                    //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
                    if (Stock.Count > 0)
                    {
                        InsertDatatoDB.insertDatatoDBStock2(Stock);
                    }
                    else
                    {
                        Console.WriteLine("File has no Data");
                    }

                    //GetStockList GetStockList = new GetStockList();
                    //List<Stock> stocks = GetStockList.getStockList();
                    //foreach (var item in stocks)
                    //{
                    //    Console.WriteLine("{0} {1} {2}", item.Product, item.ProductCode, item.Price);
                    //}
                    Console.WriteLine("Data Saved Successfully");
                    
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
            Console.ReadLine();
        }
    }
}
