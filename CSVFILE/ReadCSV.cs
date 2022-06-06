using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using CSVFILE.IServices;
using CSVFILE.Models;
using NotVisualBasic.FileIO;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace CSVFILE
{
    public class ReadCSV : IReadCSV
    {
        //public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        //{
        //    DataTable csvData = new DataTable();

        //    try
        //    {

        //        using (CsvTextFieldParser csvReader = new CsvTextFieldParser(csv_file_path))
        //        {
        //            csvReader.SetDelimiter(',');
        //            csvReader.HasFieldsEnclosedInQuotes = true;
        //            string[] colFields = csvReader.ReadFields();
        //            foreach (string column in colFields)
        //            {
        //                DataColumn datecolumn = new DataColumn(column);
        //                datecolumn.AllowDBNull = true;
        //                csvData.Columns.Add(datecolumn);
        //            }
        //            InsertDatatoDB InsertDatatoDB = new InsertDatatoDB();
        //            List<Stock> Stocks = new List<Stock>();
        //            while (!csvReader.EndOfData)
        //            {
        //                string[] fieldData = csvReader.ReadFields();
        //                Stock Stock = new Stock();
        //                //foreach (var item in fieldData)
        //                //{
        //                //    Stock.Product = item.ToString();
        //                //    //Stock.Price = item.ToString();
        //                //}
        //                Stock.Product = fieldData[0];
        //                Stock.ProductCode = fieldData[1];
        //                Stock.Price = Convert.ToDecimal(fieldData[2]);

        //                Stocks.Add(Stock);
        //                //Making empty value as null
        //                for (int i = 0; i < fieldData.Length; i++)
        //                {
        //                    if (fieldData[i] == "")
        //                    {
        //                        fieldData[i] = null;
        //                    }
        //                }
        //                csvData.Rows.Add(fieldData);

        //            }
        //            InsertDatatoDB.insertDatatoDBStock(Stocks);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return csvData;
        //}
        public List<Stock> getDataFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            List<Stock> Stocks = new List<Stock>();

            try
            {

                using (CsvTextFieldParser csvReader = new CsvTextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiter(',');
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    //InsertDatatoDB InsertDatatoDB = new InsertDatatoDB();


                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        Stock Stock = new Stock();

                        Stock.Product = fieldData[0];
                        Stock.ProductCode = fieldData[1];
                        Stock.Price = Convert.ToDecimal(fieldData[2]);

                        Stocks.Add(Stock);

                        csvData.Rows.Add(fieldData);

                    }

                    //InsertDatatoDB.insertDatatoDBStock(Stocks);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Stocks;
        }

        public List<Stock> getDataFromCSVFile2(string csv_file_path)
        {
            var streamReader = new StreamReader(csv_file_path);


            var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            var read = csvReader.Read();
            var header = csvReader.ReadHeader();
            // Then do this.
            //csvReader.Configuration.HasHeaderRecord = true;
            //csvReader.Configuration.MissingFieldFound = null;
            var records = csvReader.GetRecords<Stock>().ToList();

            List<Stock> millionrecordlist = new List<Stock>();

            foreach (var item in records)
            {
                for (int i = 0; i < 100000; i++)
                {
                    Stock Stock = new Stock();

                    Stock.Price = item.Price;
                    Stock.Product = item.Product;
                    Stock.ProductCode = item.ProductCode;
                    Stock.ProductId = item.ProductId;
                    millionrecordlist.Add(Stock);
                }
            }
            return millionrecordlist;//records;
        }
    }
}
