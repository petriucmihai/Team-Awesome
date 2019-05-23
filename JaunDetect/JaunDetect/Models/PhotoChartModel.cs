using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class PhotoChartModel
    {
        public string[] Weeks { get; set; }

        public string[] Days { get; set; }

        public int[] PhotosTakenByTime { get; set; }

        public int[] SuccessfulPhotosTaken { get; set; }

        public int[] FailedPhotosTaken { get; set; }

        public PhotoChartModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            Weeks = unit.GetWeeks(4);
            PhotosTakenByTime = random.GetRandomDatapoint(4, 20, 100);

            Days = unit.GetDays(10);
            SuccessfulPhotosTaken = random.GetRandomDatapoint(10, 1, 100);
            FailedPhotosTaken = random.GetRandomDatapoint(10, 1, 100);
            
        }
    }
}