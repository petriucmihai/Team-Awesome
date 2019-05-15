using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Models
{
    public class ResourcesDataModel
    {
        public string[] Months { get; set; }

        public int[] TestStripUsages { get; set; }

        /// <summary>
        /// Constructor for Log Model
        /// Calls to Initialize to set initial settings
        /// </summary>
        public ResourcesDataModel()
        {
            Initialize();
        }

        /// <summary>
        /// Intialize
        /// Sets default values, such as DateTime as needed by the system
        /// </summary>
        public void Initialize()
        {
            Months = getMonths(5);
            TestStripUsages = getTestStripUsages(5, 300, 400);
        }


        private string[] getMonths(int numMonthsBack)
        {
            string[] result = new string[numMonthsBack];
            List<string> months = getMonthsBackFromThisMonth(numMonthsBack);

            for (int i = 0; i < numMonthsBack - 1; i++)
            {
                result[i] = months[i];
            }

            return result;
        }

        private int[] getTestStripUsages(int num, int low, int high)
        {
            int[] result = new int[num];

            for (int i = 0; i < num - 1; i++)
            {
                result[i] = randomNumber(low, high);
            }

            return result;
        }

        private List<string> getMonthsBackFromThisMonth(int numMonthsBack)
        {
            List<string> result = new List<string>();
            DateTime thisMonth = DateTime.Now;

            for (int i = 0; i < numMonthsBack; i++)
            {
                DateTime month = thisMonth.AddMonths(-i);
                string monthString = month.ToString("MMMM");
                result.Add(monthString);
            }

            return result;
        }

        private int randomNumber(int low, int high)
        {
            Random rand = new Random();
            return rand.Next(low, high);
        }
    }
}