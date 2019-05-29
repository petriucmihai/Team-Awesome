using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Models
{
    public class QueryRecord
    {
        public string Clinic { get; set; }
        public string Province { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }

        public string BiliConcentration { get; set; }

        public string DeviceOS { get; set; }

        public bool PhotoUpload { get; set; }
    }
}