using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Models
{
    public class ResourcesChartModel
    {
        // Months that will be shown on a chart over time
        public string[] Months { get; set; }

        // Number of test strips used
        public int[] TestStripUsages { get; set; }

        // List of the clinics at which the data was tracked
        public string[] Clinics { get; set; }

        // Number of patients sent from a clinic to a nearby hospital
        public int[] HospitalPatients { get; set; }

        // Number of people that submit tests from each clinic
        public int[] ClinicWorkers { get; set; }

        // Price of a single test strip
        public double TestStripPrice { get; set; }

        // Cost of the total amount of test strips used at a clinic
        public double[] TestStripCosts { get; set; }

        // Salary of single clinic worker per hour
        public double WorkerSalary { get; set; }

        // Cost of the total workforce salary at a clinic
        public double[] SalaryCosts { get; set; }

        public ResourcesChartModel()
        {
            Initialize();
        }

        /// <summary>
        /// Intialize
        /// Sets default values, such as DateTime as needed by the system
        /// </summary>
        public void Initialize()
        {
            // None right now...
        }
    }
}