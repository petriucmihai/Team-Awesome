using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    /// <summary>
    /// In memory implementation of the JaunDetect data store
    /// </summary>
    public class DataBackendRepository : IDataRepository
    {
        ResourcesChartModel data = new ResourcesChartModel();

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

            data.Months = unit.GetMonths(5);
            data.TestStripUsages = random.GetRandomDatapoint(5, 100, 400);
            data.Clinics = unit.GetClinics(5);
            data.HospitalPatients = random.GetRandomDatapoint(5, 50, 500);
            data.TestStripPrice = 1.00;
            data.TestStripCosts = CalculateStripCost();
        }

        public string[] GetClinics()
        {
            return data.Clinics;
        }

        public int[] GetUsages()
        {
            return data.TestStripUsages;
        }

        public string[] GetMonths()
        {
            return data.Months;
        }

        public int[] GetPatients()
        {
            return data.HospitalPatients;
        }

        public double GetStripPrice()
        {
            return data.TestStripPrice;
        }

        public bool UpdateStripPrice(double price)
        {
            data.TestStripPrice = price;
            return true;
        }

        public double[] GetStripCosts()
        {
            data.TestStripCosts = CalculateStripCost();
            return data.TestStripCosts;
        }

        private double[] CalculateStripCost()
        {
            double[] result = new double[data.TestStripUsages.Count()];
            for (int i = 0; i < data.TestStripUsages.Count(); i++)
            {
                result[i] = data.TestStripUsages[i] * data.TestStripPrice;
            }
            return result;
        }
    }
}