using CSVFILE.IServices;
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
        public Program()
        {

        }
        static void Main(string[] args)
        {
            string csv_file_path = @"G:\CSVFileCSharp\CSV-Import-to-Database-Csharp\stock_list.csv";

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
                    List<Stock> Stock = ReadCSV.getDataFromCSVFile2(csv_file_path);
                    if (Stock.Count > 0)
                    {
                        InsertDatatoDB.insertDatatoDBStock2(Stock);
                    }
                    else
                    {
                        Console.WriteLine("File has no Data");
                    }
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
