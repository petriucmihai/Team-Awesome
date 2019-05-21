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
            data.Clinic = "";
            data.Province = "";
            data.Date = "";
            data.Device = "";
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
    }
}


       

      