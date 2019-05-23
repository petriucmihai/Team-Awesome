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
        public string UserInputDate { get; set; }
        public string UserInputDevice { get; set; }

        public string Clinic { get; set; }
        public string Province { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
        public List<string> List { get; set; }

        public QueryViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {

        }

    }
}