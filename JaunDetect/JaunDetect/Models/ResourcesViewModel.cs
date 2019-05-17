using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class ResourcesViewModel
    {
        public string[] Months { get; set; }

        public int[] TestStripUsages { get; set; }

        public string[] Clinics { get; set; }

        public int[] HospitalPatients { get; set; }

        /// <summary>
        /// Constructor for Log Model
        /// Calls to Initialize to set initial settings
        /// </summary>
        public ResourcesViewModel()
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

            Months = unit.GetMonths(5);
            TestStripUsages = random.GetRandomDatapoint(5, 100, 400);
            Clinics = unit.GetClinics(4);
            HospitalPatients = random.GetRandomDatapoint(4, 50, 500);
        }


        
    }
}