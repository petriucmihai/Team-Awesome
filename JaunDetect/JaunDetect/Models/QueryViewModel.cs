using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class QueryViewModel
    {
        public string Clinic { get; set; }
        public string Province { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
    }
}