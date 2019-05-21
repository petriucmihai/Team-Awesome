using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class QueryBackendRepository : IQueryRepository
    {
        QueryViewModel data = new QueryViewModel();
        public QueryBackendRepository()
        {
            Initialize();
        }

        public void Initialize()
        {
            data.Clinic = GetClinic();
            data.Province = GetProvince();
            data.Date = GetDate();
            data.Device = GetDevice();
        }

        public string GetClinic()
        {
            return data.Clinic;
        }

        public string GetProvince()
        {
            return data.Province;
        }

        public string GetDate()
        {
            return data.Date;
        }

        public string GetDevice()
        {
            return data.Device;
        }

        public bool QueryFound(int num, QueryDataBackendRepository database)
        {
            const int COLUMNS = 4;
            bool result = false; 

                if (String.Equals(data.Clinic, database.GetClinic(num)) || String.Equals(data.Province, database.GetProvince(num)) ||
                    String.Equals(data.Date, database.GetDate(num)) || String.Equals(data.Device, database.GetDevice(num)))
                {
                result = true;
                }       
            return result;             
        }
    }
}


       

      