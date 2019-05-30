﻿using JaunDetect.Backend_Data;
using JaunDetect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace JaunDetect.Controllers
{
    public class ChartController : Controller
    {
        public string[] Clinics;
        public string[] Provinces;
        public string[] Dates;
        public string[] Devices;
        public string[] BiliConcentrations;
        public string[] OSArray;
        public bool[] Uploads;

        // GET: Chart
        public ActionResult ChartView(QueryViewModel model)
        {
            if (ModelState.IsValid)
            {
                QueryBackend.Instance.UpdateVisualizationChoice(model.VisualizationChoice);

                var queryViewModel = new QueryViewModel();

                queryViewModel = QueryBackend.Instance.GetQuery();

                BuildDataSets(queryViewModel);

                return View("ChartView", queryViewModel);
            }

            return View("../Home/CustomQuery", model);
        }

        #region Line Charts
        public ActionResult GetDeviceLineChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = QueryBackend.Instance.GetQuery();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = Devices.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, Devices);

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "line",
                    xValue: distinct,
                    yValues: counts)
                .SetXAxis("Devices")
                .SetYAxis("Number of Devices")
                .Write();

            return null;
        }

        public ActionResult GetBilirubinLineChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = QueryBackend.Instance.GetQuery();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = BiliConcentrations.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, BiliConcentrations);

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "line",
                    xValue: distinct,
                    yValues: counts)
                .SetXAxis("Bilirubin %")
                .SetYAxis("Number of Cases")
                .Write();

            return null;
        }

        public ActionResult GetOSLineChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = QueryBackend.Instance.GetQuery();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = OSArray.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, OSArray);

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "line",
                    xValue: distinct,
                    yValues: counts)
                .SetXAxis("Device OS")
                .SetYAxis("Number of OS's")
                .Write();

            return null;
        }
        #endregion

        #region Column Charts
        public ActionResult GetDeviceColumnChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = QueryBackend.Instance.GetQuery();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = Devices.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, Devices);

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "column",
                    xValue: distinct,
                    yValues: counts)
                .SetXAxis("Devices")
                .SetYAxis("Number of Devices")
                .Write();

            return null;
        }

        public ActionResult GetBilirubinColumnChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = QueryBackend.Instance.GetQuery();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = BiliConcentrations.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, BiliConcentrations);

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "column",
                    xValue: distinct,
                    yValues: counts)
                .SetXAxis("Bilirubin %")
                .SetYAxis("Number of Cases")
                .Write();

            return null;
        }

        public ActionResult GetOSColumnChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = QueryBackend.Instance.GetQuery();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = OSArray.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, OSArray);

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "column",
                    xValue: distinct,
                    yValues: counts)
                .SetXAxis("Device OS")
                .SetYAxis("Number of OS's")
                .Write();

            return null;
        }
        #endregion

        private void BuildDataSets(QueryViewModel model)
        {
            Clinics = new string[model.RecordList.Count];
            Provinces = new string[model.RecordList.Count];
            Dates = new string[model.RecordList.Count];
            Devices = new string[model.RecordList.Count];
            BiliConcentrations = new string[model.RecordList.Count];
            OSArray = new string[model.RecordList.Count];
            Uploads = new bool[model.RecordList.Count];


            for (int i = 0; i < model.RecordList.Count; i++)
            {
                Clinics[i] = model.RecordList[i].Clinic;
                Provinces[i] = model.RecordList[i].Province;
                Dates[i] = model.RecordList[i].Date;
                Devices[i] = model.RecordList[i].Device;
                OSArray[i] = model.RecordList[i].DeviceOS;
                Uploads[i] = model.RecordList[i].PhotoUpload;
            }
        }

        private int[] GetNumberOfDistinctElements(string[] array, string[] data)
        {
            int[] result = new int[array.Count()];

            var groups = data.GroupBy(item => item);

            foreach (var group in groups)
            {
                int index = Array.IndexOf(array, group.Key);
                result[index] = group.Count();
            }

            return result;
        }
    }
}