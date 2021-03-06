﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JaunDetect.Backend_Data
{
    interface IDataBackendRepository
    {
        // Methods needed to provide data for charts on the Resources page
        #region Resources charts backend methods
        string[] GetClinics();

        int[] GetUsages();

        string[] GetMonths();

        int[] GetPatients();

        int[] GetClinicWorkers();

        double GetTestStripPrice();

        bool UpdateTestStripPrice(double price);

        double[] GetTestStripCosts();

        double GetWorkerSalary();

        bool UpdateWorkerSalary(double salary);

        double[] GetSalaryCosts();

        #endregion

        // Methods needed to provide data for charts on the Home page
        #region Home charts backend methods
        int[] GetBilirubinLevels();

        int[][] GetBilirubinData();

        string[][] GetTimeframe();

        string[] GetHomeClinics();

        string GetTimeOptionString();

        int GetTimeOption();

        List<SelectListItem> GetOptionsList();

        bool UpdateTimeOptionString(string timeOptionString);

        string GetClinicOptionString();

        int GetClinicOption();

        List<SelectListItem> GetClinicOptionsList();

        bool UpdateClinicOptionString(string timeOptionString);
        #endregion

        #region Crash charts backend methods
        int[] GetCrashesByTime();

        int[] GetCrashesByType();

        string[] GetCrashTypes();

        string[] GetDeviceTypes();

        string[] GetDeviceIDs();

        int[] GetCrashesByID();

        int[] GetNumbersOfDevices();

        int GetCrashesTimeOption();

        string[][] GetCrashesTimeframe();

        bool UpdateCrashTimeOptionString(string timeOptionString);

        #endregion
    }
}
