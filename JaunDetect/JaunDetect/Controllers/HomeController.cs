using System.Web.Helpers;
using System.Web.Mvc;
using JaunDetect.Models;
using JaunDetect.Backend_Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JaunDetect.Controllers
{
    public class HomeController : Controller
    {
        #region Redirect Methods

        public ActionResult Index()
        {
            var homeModel = new HomeChartModel();

            homeModel = DataBackend.Instance.GetHomeData();

            return View(homeModel);
        }

        public ActionResult UsageData()
        {
            ViewBag.Message = "Reports for App Usage";

            var usageViewModel = new UsageViewModel();

            return View(usageViewModel);
        }

        public ActionResult Resources()
        {
            ViewBag.Message = "Resources and Budgeting";

            var resourceModel = new ResourcesChartModel();

            resourceModel = DataBackend.Instance.GetResources();
            ViewBag.MONTHS = JsonConvert.SerializeObject(resourceModel.Months);
            ViewBag.TESTSTRIPS = JsonConvert.SerializeObject(resourceModel.TestStripUsages);
            return View(resourceModel);
        }

        public ActionResult CrashReport()
        {
            ViewBag.Message = "Crash Reports";

            var crashReportModel = new CrashChartModel();
            crashReportModel = DataBackend.Instance.GetCrashData();

            return View(crashReportModel);
        }

        // returns the entire mockup database prior to user input
        public ActionResult CustomQuery()
        {
            ViewBag.Message = "Custom Query";

            var queryModel = new QueryViewModel();
            queryModel = QueryBackend.Instance.GetQuery();
            return View(queryModel);
        }

        // returns matching elements following user input
        public ActionResult QueryResults(QueryViewModel model)
        {
            ViewBag.Message = "Custom Query";
            if (ModelState.IsValid)
            {
                QueryBackend.Instance.UpdateUserInputClinic(model.UserInputClinic);
                QueryBackend.Instance.UpdateUserInputProvince(model.UserInputProvince);
                QueryBackend.Instance.UpdateUserInputStartDate(model.UserInputStartDate);
                QueryBackend.Instance.UpdateUserInputEndDate(model.UserInputEndDate);
                QueryBackend.Instance.UpdateUserInputDevice(model.UserInputDevice);

                var queryViewModel = new QueryViewModel();
                queryViewModel = QueryBackend.Instance.GetSearchResults();
                return View("CustomQuery", queryViewModel); // if the query model is not valid
            }          
            return View("QueryResults", model);
        }



        public ActionResult Photos()
        {
            ViewBag.Message = "Photo Data";

            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        #endregion

        #region Usage Data Charts

        
        public JsonResult GetCommonUsageTimesChart()
        {
            var usageModel = new UsageViewModel();

            List<object> iData = new List<object>();
            iData.Add(usageModel.TimesOfDay);
            iData.Add(usageModel.UsageTimes);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDeviceModelsPieChart()
        {
            var usageModel = new UsageViewModel();

            List<object> iData = new List<object>();
            iData.Add(usageModel.DeviceTypes);
            iData.Add(usageModel.NumbersOfDevices);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAppDownloadsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            List<object> iData = new List<object>();
            iData.Add(usageModel.Months);
            iData.Add(usageModel.Downloads);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoginsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            List<object> iData = new List<object>();
            iData.Add(usageModel.Months);
            iData.Add(usageModel.Logins);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Resources Charts
        [HttpPost]
        public JsonResult GetTestStripUsageChart()
        {
            var resourceModel = new ResourcesChartModel();
            resourceModel = DataBackend.Instance.GetResources();

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(resourceModel.Months);
            iData.Add(resourceModel.TestStripUsages);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetHospitalPatientChart()
        {
            var resourceModel = new ResourcesChartModel();
            resourceModel = DataBackend.Instance.GetResources();

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(resourceModel.Clinics);
            iData.Add(resourceModel.HospitalPatients);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetClinicWorkersChart()
        {
            var resourceModel = new ResourcesChartModel();
            resourceModel = DataBackend.Instance.GetResources();

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(resourceModel.Clinics);
            iData.Add(resourceModel.ClinicWorkers);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePrice(ResourcesChartModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateStripPrice(model.TestStripPrice);

                var resourceModel = new ResourcesChartModel();

                resourceModel = DataBackend.Instance.GetResources();

                return View("Resources", resourceModel);
            }

            return View("Resources", model);
        }

        [HttpPost]
        public ActionResult UpdateSalary(ResourcesChartModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateWorkerSalary(model.WorkerSalary);

                var resourceModel = new ResourcesChartModel();

                resourceModel = DataBackend.Instance.GetResources();

                ViewBag.Section = "UpdateSalaryButton";

                return View("Resources", resourceModel);
            }

            return View("Resources", model);
        }

        #endregion

        #region Crash Report Charts

        public ActionResult GetCrashesByTimeChart()
        {
            var crashModel = new CrashChartModel();
            crashModel = DataBackend.Instance.GetCrashData();
            int num = crashModel.TimeOption;


            var key = new Chart(width: 900, height: 250)
                .AddSeries(
                    chartType: "line",
                    xValue: crashModel.Timeframe[num],
                    yValues: crashModel.CrashesByTime)
                .SetXAxis("Time")
                .SetYAxis("Total Crashes")
                .Write();

            return null;

        }

        public JsonResult GetCrashesByTypeChart()
        {
            var crashModel = new CrashChartModel();
            crashModel = DataBackend.Instance.GetCrashData();

            List<object> iData = new List<object>();
            iData.Add(crashModel.CrashTypes);
            iData.Add(crashModel.CrashesByType);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetCrashesByDeviceTypeChart()
        {
            var crashModel = new CrashChartModel();
            crashModel = DataBackend.Instance.GetCrashData();

            List<object> iData = new List<object>();
            iData.Add(crashModel.DeviceTypes);
            iData.Add(crashModel.NumbersOfDevices);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateCrashChartTimeOption(CrashChartModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateCrashTimeOptionString(model.TimeOptionString);
                ViewBag.Section = "CrashTimeOption";

                var crashModel = new CrashChartModel();

                crashModel = DataBackend.Instance.GetCrashData();

                return View("CrashReport", crashModel);
            }

            return View("Crash Report", model);
        }
        #endregion

        #region Home Charts

        [HttpPost]
        public JsonResult GetTestNumbersForAllClinicsChart()
        {
            var homeModel = new HomeChartModel();
            homeModel = DataBackend.Instance.GetHomeData();
            int num = homeModel.TimeOption;

            List<object> iData = new List<object>();

            for (int i = 0; i < homeModel.BilirubinData.Length; i++)
            {
                iData.Add(homeModel.Timeframe[num]);
                iData.Add(homeModel.BilirubinData[i]);
                iData.Add(new List<string> { "Clinic " + homeModel.Clinics[i] });
            }

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetClinicBilirubinLevelChart()
        {
            var homeModel = new HomeChartModel();
            homeModel = DataBackend.Instance.GetHomeData();
            int num = homeModel.ClinicOption;


            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            // 3. X-Axis label
            List<object> iData = new List<object>();
            iData.Add(homeModel.ConvertDataToString(homeModel.BilirubinLevels));
            iData.Add(homeModel.BilirubinData[num]);
            iData.Add(new List<string> { "Clinic " + homeModel.Clinics[num] });

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UpdateHomeChartTimeOption(HomeChartModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateTimeOptionString(model.TimeOptionString);

                ViewBag.Section = "TestNumberByClinic";

                var homeModel = new HomeChartModel();

                homeModel = DataBackend.Instance.GetHomeData();

                return View("Index", homeModel);
            }

            return View("Resources", model);
        }

        [HttpPost]
        public ActionResult UpdateHomeChartClinicOption(HomeChartModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateClinicOptionString(model.ClinicOptionString);

                ViewBag.Section = "Bili%ByClinic";

                var homeModel = new HomeChartModel();

                homeModel = DataBackend.Instance.GetHomeData();

                return View("Index", homeModel);
            }

            return View("Resources", model);
        }



        #endregion

        #region Photo Charts
        
        public JsonResult GetPhotosTakenByTimeChart()
        {
            var photoModel = new PhotoChartModel();

            // Order of data in the list:
            // 1. X-Values (labels)
            // 2. Y-Values (data)
            List<object> iData = new List<object>();
            iData.Add(photoModel.Weeks);
            iData.Add(photoModel.PhotosTakenByTime);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

       

        public JsonResult GetSuccessfulFailedPhotosTaken()
        {
            var photoModel = new PhotoChartModel();

            List<object> iData = new List<object>();
            iData.Add(photoModel.Days);
            iData.Add(photoModel.SuccessfulPhotosTaken);
            iData.Add(photoModel.FailedPhotosTaken);

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        private string GetTheme()
        {
            var myTheme = @"<Chart BorderlineDashStyle=""Solid"" BorderWidth=""1"">

    <ChartAreas>
         <ChartArea Name=""Default"" _Template_=""All""> 
      <AxisY LineColor = ""Gainsboro""> 
        <LabelStyle Font=""Helvetica Neue, 90px"" /> 
        <MajorGrid LineColor = ""Gainsboro"" />
      </AxisY> 
<AxisX LineColor = ""Gainsboro"">
        <MajorGrid LineColor = ""Gainsboro"" />
        <LabelStyle Font=""Helvetica Neue, 90px"" /> 
      </AxisX>
    </ChartArea>
    </ChartAreas>
  </Chart>";

            return myTheme;
        }

        


    }
}