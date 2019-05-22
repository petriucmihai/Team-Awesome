﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Models;
using System.Data;

namespace JaunDetect.Backend_Data
{
    public class QueryDataBackendRepository : IQueryDataRepository
    {
        const int ROWS = 10;
        const int COLUMNS = 4;
        string[,] queryrows = new string[ROWS, COLUMNS];
        string[] clinics = { "Lagos First Clinic", "Lagos Second Clinic", "Onitsha Clinic", "Kano Clinic", "Ibadan Clinic",
            "Uyo Clinic", "Nsukka Clinic", "Abuja First Clinic", "Abuja Second Clinic", "Aba Clinic" };
        string[] provinces = { "Lagos", "Lagos", "Onitsha", "Kano", "Ibadan", "Uyo", "Nsukka", "Abuja", "Abuja", "Aba" };
        string[] dates = { "1/1/2019", "2/2/2019", "3/3/2019", "4/4/2019", "5/5/2019", "6/6/2019", "7/7/2019", "8/8/2019", "9/9/2019", "10/10/2019" };
        string[] devices = { "Samsung Galaxy S8", "Samsung Galaxy Note", "Sony Xperia", "Sony Xperia", "Tecno Spark", "Motorola One", "Huawei Y9", "Huawei P10", "Huawei P10", "OnePlus 5" };

        public QueryDataBackendRepository()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < ROWS; i++)
            {
                queryrows[i, 0] = clinics[i];
                queryrows[i, 1] = provinces[i];
                queryrows[i, 2] = dates[i];
                queryrows[i, 3] = devices[i];
            }
        }

        public string GetClinic(int num)
        {
            return queryrows[num, 0];
        }

        public string GetProvince(int num)
        {
            return queryrows[num, 1];
        }

        public string GetDate(int num)
        {
            return queryrows[num, 2];
        }

        public string GetDevice(int num)
        {
            return queryrows[num, 3];
        }

        public DataTable GetDataTable()
        {
            const int ROWS = 10;

            
            QueryViewModel userData = new QueryViewModel();
            DataTable dt = new DataTable("Query Results");
            dt.Columns.Add(new DataColumn("Clinic"));
            dt.Columns.Add(new DataColumn("Province"));
            dt.Columns.Add(new DataColumn("Date"));
            dt.Columns.Add(new DataColumn("Device"));
            for (int i = 0; i < ROWS; i++)
            {
                if (String.Equals(userData.Clinic, GetClinic(i)) || String.Equals(userData.Province, GetProvince(i)) ||
                    String.Equals(userData.Date, GetDate(i)) || String.Equals(userData.Device, GetDevice(i)))
                {
                    dt.Rows.Add(GetClinic(i), GetProvince(i), GetDate(i), GetDevice(i));
                }
            }
            return dt; 
        }
    }
}


