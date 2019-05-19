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
            Initialize();
        }

        public void Initialize()
        {    
            ClinicName = Console.ReadLine();
            StartTime = Console.ReadLine();
            EndTime = Console.ReadLine();
            Device = Console.ReadLine();
        }
    }
}