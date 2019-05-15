using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class UsageViewModel
    {
        // Number of users that are currently using the phone application
        public int CurrentUsers { get; set; }

        // Amount of usages at each unit time of day
        public int[] UsageTimes { get; set; }

        // Names for the units of time of day
        public string[] TimesOfDay { get; set; }

        // Number of each type of device among the userbase
        public int[] NumbersOfDevices { get; set; }

        // List of the different types of devices the phone application is used on
        public string[] DeviceTypes { get; set; }

        // Number of app downloads for each unit time
        public int[] Downloads { get; set; }

        // Months going backwards from this month
        public string[] Months { get; set; }

        // Number of app logins for each unit time
        public int[] Logins { get; set; }

        /// <summary>
        /// Constructor for UsageViewModel
        /// Calls to Initialize to set initial settings
        /// </summary>
        public UsageViewModel()
        {
            Initialize();
        }

        /// <summary>
        /// Intialize
        /// Sets default values, such as DateTime as needed by the system
        /// </summary>
        public void Initialize()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            CurrentUsers = random.GetRandomInt(10, 50);

            // Break the day up into 7 units: 2 hour intervals from 8AM to 8PM
            UsageTimes = random.GetRandomDatapoint(7, 10, 50);
            //TimesOfDay = 8AM, 10AM, 12PM, etc.

            // 6 types of devices
            NumbersOfDevices = random.GetRandomDatapoint(6, 3, 30);
            //DeviceTypes = Samsung Galaxy, Google Pixel, etc.

            Months = unit.GetMonths(5);
            Logins = random.GetRandomDatapoint(5, 100, 500);
            Downloads = random.GetRandomDatapoint(5, 50, 200);
        }


    }
}