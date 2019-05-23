using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;


namespace JaunDetect.Models
{
    public class QueryResultViewModel
    {
        public string Clinic { get; set; }
        public string Province { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
        public List<string> List { get; set; }

        public QueryResultViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            
        }
    }

}