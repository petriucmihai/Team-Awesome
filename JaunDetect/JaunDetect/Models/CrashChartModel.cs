using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class CrashChartModel
    {
        public string[][] Timeframe { get; set; }

        public string TimeOptionString { get; set; }

        public int TimeOption { get; set; }

        public List<SelectListItem> OptionsList { get; set; }

        // Number of crashes by time
        public int[] CrashesByTime { get; set; }

        // Number of crashes by type
        public int[] CrashesByType { get; set; }

        // Types of crashes
        public string[] CrashTypes
        { get; set; }

        // Number of each type of device among the userbase
        public int[] NumbersOfDevices { get; set; }

        // List of the different types of devices the phone application is used on
        public string[] DeviceTypes { get; set; }

        public string[] DeviceIDs { get; set; }

        public int[] CrashesByID { get; set; }

        // Constructor
        public CrashChartModel()
        {
            
        }

        
    }
}