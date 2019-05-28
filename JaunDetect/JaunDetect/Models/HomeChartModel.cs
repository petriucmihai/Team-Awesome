using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class HomeChartModel
    {
        public int[] BilirubinLevels { get; set; }

        public int[][] BilirubinData { get; set; }

        public string[] Clinics { get; set; }

        public string[][] Timeframe { get; set; }

        public string TimeOptionString { get; set; }

        public int TimeOption { get; set; }

        public List<SelectListItem> TimeOptionsList { get; set; }
        
        public string ClinicOptionString { get; set; }

        public int ClinicOption { get; set; }

        public List<SelectListItem> ClinicOptionsList { get; set; }

        public HomeChartModel()
        {
            //Initialize();
        }

        public string[] ConvertDataToString(int[] data)
        {
            string[] result = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = data[i].ToString() + "%";
            }
            return result;
        }
    }
}