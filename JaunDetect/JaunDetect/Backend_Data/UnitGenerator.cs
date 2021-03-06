﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Backend_Data
{
    public class UnitGenerator
    {

        public string[] GetClinics(int num)
        {
            string[] result = new string[num];
            string[] cities = { "Lagos", "Onitsha", "Kano", "Ibadan", "Uyo", "Nsukka", "Abuja", "Aba" };

            for (int i = 0; i < num; i++)
            {
                result[i] = cities[i];
            }

            return result;
        }

        public string[] GetWeeks(int numWeeksBack)
        {
            string[] result = new string[numWeeksBack];
            List<string> weeks = getWeeksBackFromThisWeek(numWeeksBack);

            for (int i = 0; i < numWeeksBack; i++)
            {
                result[i] = weeks[numWeeksBack - 1 - i];
            }

            return result;
        }

        private List<string> getWeeksBackFromThisWeek(int numWeeksBack)
        {
            List<string> result = new List<string>();
            DateTime thisWeek = DateTime.Now;

            for (int i = 0; i < numWeeksBack * 7; i+= 7)
            {
                DateTime week1 = thisWeek.AddDays(-i - 7);
                string weekString = week1.ToString("MMMM dd");
                DateTime week2 = thisWeek.AddDays(-i);
                weekString += " - " + week2.ToString("MMMM dd");
                result.Add(weekString);
            }

            return result;
        }

        public string[] GetMonths(int numMonthsBack)
        {
            string[] result = new string[numMonthsBack];
            List<string> months = getMonthsBackFromThisMonth(numMonthsBack);

            for (int i = 0; i < numMonthsBack; i++)
            {
                result[i] = months[numMonthsBack-1-i];
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

        public string[] GetYears(int numYearsBack)
        {
            string[] result = new string[numYearsBack];
            List<string> years = getYearsBackFromThisYear(numYearsBack);

            for (int i = 0; i < numYearsBack; i++)
            {
                result[i] = years[numYearsBack - 1 - i];
            }

            return result;
        }

        private List<string> getYearsBackFromThisYear(int numYearsBack)
        {
            List<string> result = new List<string>();
            DateTime thisYear = DateTime.Now;

            for (int i = 0; i < numYearsBack; i++)
            {
                DateTime year = thisYear.AddYears(-i);
                string yearString = year.ToString("yyyy");
                result.Add(yearString);
            }

            return result;
        }

        public string[] GetDays(int numDaysBack)
        {
            string[] result = new string[numDaysBack];
            List<string> days = getDaysBackFromToday(numDaysBack);

            for (int i = 0; i < numDaysBack; i++)
            {
                result[i] = days[numDaysBack-1-i];
            }

            return result;
        }

        private List<string> getDaysBackFromToday(int numDaysBack)
        {
            List<string> result = new List<string>();
            DateTime today = DateTime.Now;

            for (int i = 0; i < numDaysBack; i++)
            {
                DateTime day = today.AddDays(-i);
                string dayString = day.ToString("dddd");
                result.Add(dayString);
            }

            return result;
        }
        public string[] GetDevices(int num)
        {
            string[] result = new string[num];
            string[] devices = { "Samsung Galaxy S8", "Samsung Galaxy Note", "Sony Xperia", "Tecno Spark", "Motorola One", "Huawei Y9", "Huawei P10", "OnePlus 5" };

            for (int i = 0; i < num; i++)
            {
                result[i] = devices[i];
            }

            return result;
        }

        public string[] GetTimesOfDay(int num, int multiplier)
        {
            string[] result = new string[num];

            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);

            for (int i = 0; i < num; i++)
            {
                DateTime add = start.AddHours(i * multiplier);
                result[i] = add.ToString("h:mm tt");
            }


            return result;
        }
    }
}