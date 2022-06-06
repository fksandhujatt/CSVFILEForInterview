using CSVFILE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVFILE.IServices
{
    interface IGetStockList
    {
        List<Stock> getStockList();
    }
}
