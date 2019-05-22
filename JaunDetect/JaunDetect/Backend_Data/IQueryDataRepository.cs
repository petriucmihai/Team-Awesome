using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JaunDetect.Backend_Data
{
    interface IQueryDataRepository
    {
        string GetClinic(int num);
        string GetProvince(int num);
        string GetDate(int num);
        string GetDevice(int num);
         string[] GetDataTable();
    }
}