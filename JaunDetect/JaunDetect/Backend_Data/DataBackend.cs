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
            myData.ClinicWorkers = repository.GetClinicWorkers();
            myData.Months = repository.GetMonths();
            myData.TestStripUsages = repository.GetUsages();
            myData.TestStripPrice = repository.GetTestStripPrice();
            myData.TestStripCosts = repository.GetTestStripCosts();
            myData.WorkerSalary = repository.GetWorkerSalary();
            myData.SalaryCosts = repository.GetSalaryCosts();

            return myData;
        }

        public HomeChartModel GetHomeData()
        {
            var myData = new HomeChartModel();
            myData.BilirubinData = repository.GetBilirubinData();
            myData.BilirubinLevels = repository.GetBilirubinLevels();
            myData.Clinics = repository.GetHomeClinics();
            myData.TimeOptionsList = repository.GetOptionsList();
            myData.Timeframe = repository.GetTimeframe();
            myData.TimeOption = repository.GetTimeOption();
            myData.TimeOptionString = repository.GetTimeOptionString();
            myData.ClinicOption = repository.GetClinicOption();
            myData.ClinicOptionString = repository.GetClinicOptionString();
            myData.ClinicOptionsList = repository.GetClinicOptionsList();

            return myData;
        }

        public CrashChartModel GetCrashData()
        {
            var myData = new CrashChartModel();
            myData.CrashesByTime = repository.GetCrashesByTime();
            myData.CrashesByType = repository.GetCrashesByType();
            myData.CrashTypes = repository.GetCrashTypes();
            myData.DeviceTypes = repository.GetDeviceTypes();
            myData.DeviceIDs = repository.GetDeviceIDs();
            myData.CrashesByID = repository.GetCrashesByID();
            myData.NumbersOfDevices = repository.GetNumbersOfDevices();
            myData.OptionsList = repository.GetOptionsList();
            myData.Timeframe = repository.GetCrashesTimeframe();
            myData.TimeOption = repository.GetTimeOption();
            myData.TimeOptionString = repository.GetTimeOptionString();

            return myData;
        }

        public bool UpdateStripPrice(double price)
        {
            return repository.UpdateTestStripPrice(price);
        }

        public bool UpdateWorkerSalary(double salary)
        {
            return repository.UpdateWorkerSalary(salary);
        }

        public bool UpdateTimeOptionString(string timeOptionString)
        {
            return repository.UpdateTimeOptionString(timeOptionString);
        }

        public bool UpdateCrashTimeOptionString(string timeOptionString)
        {
            return repository.UpdateCrashTimeOptionString(timeOptionString);
        }
    }
}