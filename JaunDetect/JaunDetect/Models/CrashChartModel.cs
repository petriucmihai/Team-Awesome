using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class CrashChartModel
    {
        // Days going back from today
        public string[] Days { get; set; }

        // Months going back from this month
        public string[] Months { get; set; }

        // Number of crashes by time
        public int[] CrashesByTime { get; set; }

        // Number of crashes by type
        public int[] CrashesByType { get; set; }

        // Types of crashes
        public string[] CrashTypes
        { get; set; }

        // Constructor
        public CrashChartModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            // init crashtypes
            // init crashes by type
            // init crashes by time
            // init months
            // init days
        }
    }
}