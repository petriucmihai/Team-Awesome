using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JaunDetect.Backend_Data;

namespace JaunDetect.Models
{
    public class HomeChartModel
    {
        public int[] BilirubinLevels { get; set; }

        public int[][] BilirubinData { get; set; }

        public string[] Clinics { get; set; }

        public string[][] Timeframe { get; set; }

        public string TimeOption { get; set; }

        public List<SelectListItem> OptionsList { get; set; } 

        public HomeChartModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            RandomDataGenerator random = new RandomDataGenerator();
            UnitGenerator unit = new UnitGenerator();

            Clinics = unit.GetClinics(5);
            BilirubinLevels = new int[] { 5, 10, 15, 20, 25 };

            int[][] data = new int[BilirubinLevels.Length][];
            for (int i = 0; i < 5; i++)
            {
                data[i] = random.GetRandomDatapoint(5, 50, 200);
            }

            BilirubinData = data;

            Timeframe = new string[3][];
            Timeframe[0] = unit.GetMonths(5);
            Timeframe[1] = new string[] { "Week1", "Week2", "Week3", "Week4", "Week5" };
            Timeframe[2] = new string[] { "Year1", "Year2", "Year3", "Year4", "Year5" };

            CreateSelectList();
        }

        private void CreateSelectList()
        {
            SelectListItem listItem1 = new SelectListItem
            {
                Text = "Months",
                Value = "1"
            };
            SelectListItem listItem2 = new SelectListItem
            {
                Text = "Weeks",
                Value = "2"
            };
            SelectListItem listItem3 = new SelectListItem
            {
                Text = "Years",
                Value = "3"
            };

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(listItem1);
            items.Add(listItem2);
            items.Add(listItem3);

            OptionsList = items;

        }
    }
}