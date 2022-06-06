using CSVFILE.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSVFILE
{
    public class InsertDatatoDB
    {
        public void insertDatatoDBStock(List<Stock> Stock)
        {
            try
            {
                using (CSVFILEContext db = new CSVFILEContext())
                {
                    db.AddRange(Stock);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
        }
        public void insertDatatoDBStock2(List<Stock> Stock)
        {
            try
            {
                using (CSVFILEContext db = new CSVFILEContext())
                {
                    //db.SaveChanges();
                    //db.AddRangeAsync(Stock);
                    Stock Stocks = new Stock();
                     DataTable table = new DataTable();
                    table.TableName = "Stock";

                    table.Columns.Add(nameof(Stocks.ProductId), typeof(Int64));
                    table.Columns.Add(nameof(Stocks.Product), typeof(string));
                    table.Columns.Add(nameof(Stocks.ProductCode), typeof(string));
                    table.Columns.Add(nameof(Stocks.Price), typeof(decimal));

                    foreach (var item in Stock)
                    {
                        var row = table.NewRow();
                        row[nameof(Stocks.Price)] = item.Price ?? (object)DBNull.Value;
                        row[nameof(Stocks.ProductCode)] = item.ProductCode ?? (object)DBNull.Value;
                        row[nameof(Stocks.Product)] = item.Product ?? (object)DBNull.Value;
                        row[nameof(Stocks.ProductId)] = item.ProductId;
                        table.Rows.Add(row);
                    }

                    using (var bulkInsert = new SqlBulkCopy(db.Database.GetDbConnection().ConnectionString))
                    {
                        bulkInsert.BulkCopyTimeout = 0;
                        bulkInsert.DestinationTableName = table.TableName;
                        bulkInsert.WriteToServer(table);
                    }
                }
            }
            catch (Exception ex)
            {

                //throw;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
