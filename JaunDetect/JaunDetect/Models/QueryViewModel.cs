using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;


namespace JaunDetect.Models
{
    public class QueryViewModel
    {
        public string UserInputClinic { get; set; }
        public string UserInputProvince { get; set; }
        public string UserInputStartDate { get; set; }
        public string UserInputEndDate { get; set; }
        public string UserInputDevice { get; set; }
        public int VisualizationChoice { get; set; }

        public string Clinic { get; set; }
        public string Province { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
        public string BiliConcentrations { get; set; }
        public string DeviceOS { get; set; }
        public bool PhotoUpload { get; set; }

        public List<QueryRecord> RecordList { get; set; }

        public QueryViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            
        }

    }
}