using System.Collections.Generic;

namespace JaunDetect.Models
{
    // lists all the get/set methods and fields of the QueryViewModel
    public class QueryViewModel
    {
        // user input to compare with database elements
        public string UserInputClinic { get; set; }
        public string UserInputProvince { get; set; }
        public string UserInputStartDate { get; set; }
        public string UserInputEndDate { get; set; }
        public string UserInputDevice { get; set; }
        public int VisualizationChoice { get; set; }

        // mockup database elements
        public string Clinic { get; set; }
        public string Province { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
        public string BiliConcentrations { get; set; }
        public string DeviceOS { get; set; }
        public bool FailedPhoto { get; set; }

        // the list that holds database elements
        public List<QueryRecord> RecordList { get; set; }
    }
}