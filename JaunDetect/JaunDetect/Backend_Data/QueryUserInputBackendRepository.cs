﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class QueryUserInputBackendRepository : IQueryUserInputRepository
    {
        QueryViewModel userData = new QueryViewModel();
        public QueryUserInputBackendRepository()
        {
            Initialize();
        }

        public void Initialize()
        {
            userData.Clinic = GetClinic();
            userData.Province = GetProvince();
            userData.Date = GetDate();
            userData.Device = GetDevice();
        }
        
        public string GetClinic()
        {
            return userData.Clinic;
        }

        public string GetProvince()
        {
            return userData.Province;
        }

        public string GetDate()
        {
            return userData.Date;
        }

        public string GetDevice()
        {
            return userData.Device;
        }

    
        public bool UpdateClinic(string newData)
        {
            userData.Clinic = newData;
            return true;
        }

        public bool UpdateProvince(string newData)
        {
            userData.Province = newData;
            return true;
        }

        public bool UpdateDate(string newData)
        {
            userData.Date = newData;
            return true;
        }

        public bool UpdateDevice(string newData)
        {
            userData.Device = newData;
            return true;
        }
    }
}


       

      