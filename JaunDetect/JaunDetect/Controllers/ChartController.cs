using JaunDetect.Backend_Data;
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
                Backend.Instance.UpdateVisualizationChoice(model.VisualizationChoice);

                var queryViewModel = new QueryViewModel();

                queryViewModel = Backend.Instance.GetSearchResults();

                BuildDataSets(queryViewModel);

                return View("ChartView", queryViewModel);
            }

            return View("../Home/CustomQuery", model);
        }

        #region Charts
        [HttpPost]
        public JsonResult GetTestsPerDateChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = Backend.Instance.GetSearchResults();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = Dates.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, Dates);

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(distinct);
            iData.Add(counts);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDeviceChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = Backend.Instance.GetSearchResults();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = Devices.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, Devices);

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(distinct);
            iData.Add(counts);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetBilirubinChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = Backend.Instance.GetSearchResults();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = BiliConcentrations.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, BiliConcentrations);

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(distinct);
            iData.Add(counts);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetOSChart()
        {
            var queryViewModel = new QueryViewModel();

            queryViewModel = Backend.Instance.GetSearchResults();

            BuildDataSets(queryViewModel);

            //test code for devices dataset
            var distinct = OSArray.Distinct().ToArray();
            var counts = GetNumberOfDistinctElements(distinct, OSArray);

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(distinct);
            iData.Add(counts);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
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
                Uploads[i] = model.RecordList[i].FailedPhoto;
                BiliConcentrations[i] = model.RecordList[i].BiliConcentration;
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