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

            string[] types = { "Device Incompatibility", "Force Close by User", "Fatal Bug", "Connectivity Exception", "Exception Handling/Error Condition" };
            CrashTypes = types;
            // init crashes by type
            CrashesByType = random.GetRandomDatapoint(5, 0, 30);
            // init crashes by time
            CrashesByTime = random.GetRandomDatapoint(5, 0, 30);
            // init months
            Months = unit.GetMonths(5);
            // init days
            Days = unit.GetDays(5);
        }
    }
}