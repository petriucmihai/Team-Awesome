using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class CustomQueryViewModel
    {

        public string ClinicName { get; set; }

        public string Province { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Device { get; set; }

        public CustomQueryViewModel()
        {
            QueryInitializer();
        }

        public void QueryInitializer()
        {
            //ClinicName = Console.ReadLine();
            //Province = Console.ReadLine();
            //StartTime = Console.ReadLine();
            //EndTime = Console.ReadLine();
            //Device = Console.ReadLine();

          
            //ClinicName = "Lagos Clinic";
            //Province = "Lagos";
            //StartTime = "1/1/2019"; 
            //EndTime = "6/1/2019";
            //Device = "Android"; 
        }
    }
}