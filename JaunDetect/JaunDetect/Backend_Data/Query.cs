using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Backend_Data
{
    public class Query
    {

            public int count = 0;
            public int ID { get; set; }

            public string ClinicName { get; set; }

            public string Province { get; set; }

            public string StartTime { get; set; }

            public string EndTime { get; set; }

            public string Device { get; set; }

            public Query()
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

            ClinicName = "";
            Province = "";
            StartTime = "";
            EndTime = "";
            Device = "";

        }
    }
}
