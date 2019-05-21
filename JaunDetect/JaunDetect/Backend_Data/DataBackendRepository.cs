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
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            resourcesData.Months = unit.GetMonths(5);
            resourcesData.TestStripUsages = random.GetRandomDatapoint(5, 100, 400);
            resourcesData.Clinics = unit.GetClinics(5);
            resourcesData.HospitalPatients = random.GetRandomDatapoint(5, 50, 500);
            resourcesData.TestStripPrice = 1.00;
            resourcesData.TestStripCosts = CalculateTestStripCost();
        }

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

        public string GetTimeOption()
        {
            return homeData.TimeOption;
        }

        public List<SelectListItem> GetOptionsList()
        {
            return homeData.OptionsList;
        }

        public bool UpdateTimeOption(string timeOption)
        {
            homeData.TimeOption = timeOption;
            return true;
        }
    }
}