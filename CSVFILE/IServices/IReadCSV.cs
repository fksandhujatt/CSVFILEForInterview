using CSVFILE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVFILE.IServices
{
    interface IReadCSV
    {
        List<Stock> getDataFromCSVFile(string csv_file_path);
    }
}
