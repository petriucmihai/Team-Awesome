using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class DataBackend
    {
        #region SingletonPattern
        private static volatile DataBackend instance;
        private static object syncRoot = new object();

        private DataBackend() { }

        public static DataBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DataBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private IDataRepository repository = new DataBackendRepository();

        public ResourcesChartModel GetResources()
        {
            var myData = new ResourcesChartModel();
            myData.Clinics = repository.GetClinics();
            myData.HospitalPatients = repository.GetPatients();
            myData.Months = repository.GetMonths();
            myData.TestStripUsages = repository.GetUsages();
            myData.TestStripPrice = repository.GetTestStripPrice();
            myData.TestStripCosts = repository.GetTestStripCosts();

            return myData;
        }

        public HomeChartModel GetHomeData()
        {
            var myData = new HomeChartModel();


            return myData;
        }

        public bool UpdateStripPrice(double price)
        {
            return repository.UpdateTestStripPrice(price);
        }
    }
}