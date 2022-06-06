using CSVFILE.IServices;
using CSVFILE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVFILE
{
    public class GetStockList : IGetStockList
    {
        public List<Stock> getStockList()
        {
            try
            {
                List<Stock> stocks = new List<Stock>();

                using (CSVFILEContext db = new CSVFILEContext())
                {
                    
                   return db.Stock.ToList();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

