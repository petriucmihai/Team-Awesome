using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    /// <summary>
    /// In memory implementation of the JaunDetect data store
    /// </summary>
    public class DataBackendRepository : IDataRepository
    {
        ResourcesChartModel resourcesData = new ResourcesChartModel();
        HomeChartModel homeData = new HomeChartModel();
        CrashChartModel crashesData = new CrashChartModel();

        /// <summary>
        /// Constructor for data repository
        /// </summary>
        public DataBackendRepository()
        {
            Initialize();
        }

        /// <summary>
        /// Random seed data initialized and stored in repository
        /// </summary>
        public void Initialize()
        {
            InitializeResources();
            InitializeHome();
            InitializeCrashReport();
        }

        public void InitializeResources()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            resourcesData.Months = unit.GetMonths(5);
            resourcesData.TestStripUsages = random.GetRandomDatapoint(5, 100, 400);
            resourcesData.Clinics = unit.GetClinics(5);
            resourcesData.HospitalPatients = random.GetRandomDatapoint(5, 50, 500);
            resourcesData.TestStripPrice = 1.00;
            resourcesData.TestStripCosts = CalculateTestStripCost();
        }

        public void InitializeHome()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            homeData.Clinics = unit.GetClinics(5);
            homeData.BilirubinLevels = new int[] { 5, 10, 15, 20, 25 };

            int[][] data = new int[homeData.BilirubinLevels.Length][];
            for (int i = 0; i < 5; i++)
            {
                data[i] = random.GetRandomDatapoint(5, 50, 200);
            }

            homeData.BilirubinData = data;

            homeData.TimeOption = 0;

            homeData.Timeframe = new string[3][];
            homeData.Timeframe[0] = unit.GetMonths(5);
            homeData.Timeframe[1] = unit.GetWeeks(5);
            homeData.Timeframe[2] = unit.GetYears(5);

            CreateSelectList();
        }

        public void InitializeCrashReport()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            string[] types = { "Device Incompatibility", "Force Close by User", "Fatal Bug", "Connectivity Exception", "Exception Handling" };
            crashesData.CrashTypes = types;
            // init crashes by type and by time
            crashesData.CrashesByType = random.GetRandomDatapoint(5, 0, 30);
            crashesData.CrashesByTime = random.GetRandomDatapoint(9, 0, 30);

            // 6 types of devices
            crashesData.NumbersOfDevices = random.GetRandomDatapoint(6, 3, 30);
            crashesData.DeviceTypes = unit.GetDevices(6);

            crashesData.TimeOption = 0;

            crashesData.Timeframe = new string[3][];
            crashesData.Timeframe[0] = unit.GetMonths(9);
            crashesData.Timeframe[1] = unit.GetWeeks(9);
            crashesData.Timeframe[2] = unit.GetYears(9);

            CreateSelectList();
        }

        #region Resources charts methods

        public string[] GetClinics()
        {
            return resourcesData.Clinics;
        }

        public int[] GetUsages()
        {
            return resourcesData.TestStripUsages;
        }

        public string[] GetMonths()
        {
            return resourcesData.Months;
        }

        public int[] GetPatients()
        {
            return resourcesData.HospitalPatients;
        }

        public double GetTestStripPrice()
        {
            return resourcesData.TestStripPrice;
        }

        public bool UpdateTestStripPrice(double price)
        {
            resourcesData.TestStripPrice = price;
            return true;
        }

        public double[] GetTestStripCosts()
        {
            resourcesData.TestStripCosts = CalculateTestStripCost();
            return resourcesData.TestStripCosts;
        }

        private double[] CalculateTestStripCost()
        {
            double[] result = new double[resourcesData.TestStripUsages.Count()];
            for (int i = 0; i < resourcesData.TestStripUsages.Count(); i++)
            {
                result[i] = resourcesData.TestStripUsages[i] * resourcesData.TestStripPrice;
            }
            return result;
        }

        #endregion

        #region Homepage charts methods 

        public int[] GetBilirubinLevels()
        {
            return homeData.BilirubinLevels;
        }

        public int[][] GetBilirubinData()
        {
            return homeData.BilirubinData;
        }


        public string[][] GetTimeframe()
        {
            return homeData.Timeframe;
        }

        public string[] GetHomeClinics()
        {
            return homeData.Clinics;
        }

        public string GetTimeOptionString()
        {
            return homeData.TimeOptionString;
        }

        public int GetTimeOption()
        {
            return homeData.TimeOption;
        }

        public List<SelectListItem> GetOptionsList()
        {
            return homeData.OptionsList;
        }

        public bool UpdateTimeOptionString(string timeOptionString)
        {
            homeData.TimeOptionString = timeOptionString;
            homeData.TimeOption = int.Parse(timeOptionString);
            refreshData();
            return true;
        }

        private void refreshData()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            int[][] data = new int[homeData.BilirubinLevels.Length][];
            for (int i = 0; i < 5; i++)
            {
                data[i] = random.GetRandomDatapoint(5, 50, 200);
            }

            homeData.BilirubinData = data;
        }

        private void CreateSelectList()
        {
            SelectListItem listItem1 = new SelectListItem
            {
                Text = "Months",
                Value = "0"
            };
            SelectListItem listItem2 = new SelectListItem
            {
                Text = "Weeks",
                Value = "1"
            };
            SelectListItem listItem3 = new SelectListItem
            {
                Text = "Years",
                Value = "2"
            };

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(listItem1);
            items.Add(listItem2);
            items.Add(listItem3);

            homeData.OptionsList = items;
            crashesData.OptionsList = items;

        }

        #endregion


        public int[] GetCrashesByTime()
        {
            return crashesData.CrashesByTime;
        }

        public int[] GetCrashesByType()
        {
            return crashesData.CrashesByType;
        }

        public string[] GetCrashTypes()
        {
            return crashesData.CrashTypes;
        }

        public string[] GetDeviceTypes()
        {
            return crashesData.DeviceTypes;
        }

        public int[] GetNumbersOfDevices()
        {
            return crashesData.NumbersOfDevices;
        }

        public string[][] GetCrashesTimeframe()
        {
            return crashesData.Timeframe;
        }

        public bool UpdateCrashTimeOptionString(string timeOptionString)
        {
            crashesData.TimeOptionString = timeOptionString;
            crashesData.TimeOption = int.Parse(timeOptionString);
            refreshCrashData();
            return true;
        }
        private void refreshCrashData()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            crashesData.CrashesByTime = random.GetRandomDatapoint(9, 0, 30);
        }

    }
}