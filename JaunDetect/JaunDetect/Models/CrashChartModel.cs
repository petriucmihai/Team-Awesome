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

        // Number of each type of device among the userbase
        public int[] NumbersOfDevices { get; set; }

        // List of the different types of devices the phone application is used on
        public string[] DeviceTypes { get; set; }

        // Constructor
        public CrashChartModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            string[] types = { "Device Incompatibility", "Force Close by User", "Fatal Bug", "Connectivity Exception", "Exception Handling" };
            CrashTypes = types;
            // init crashes by type and by time
            CrashesByType = random.GetRandomDatapoint(5, 0, 30);
            CrashesByTime = random.GetRandomDatapoint(8, 0, 30);

            Months = unit.GetMonths(8);
            Days = unit.GetDays(8);

            // 6 types of devices
            NumbersOfDevices = random.GetRandomDatapoint(6, 3, 30);
            DeviceTypes = unit.GetDevices(6);
        }
    }
}