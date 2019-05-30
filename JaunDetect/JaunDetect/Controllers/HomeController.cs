using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using JaunDetect.Models;
using JaunDetect.Backend_Data;
using Newtonsoft.Json;

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


        public ActionResult CustomQuery()
        {
            ViewBag.Message = "Custom Query";

            var queryModel = new QueryViewModel();
            queryModel = QueryBackend.Instance.GetQuery();
            return View(queryModel);
        }

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

                return View("CustomQuery", queryViewModel);
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

        public ActionResult GetCommonUsageTimesChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "column",
                    xValue: usageModel.TimesOfDay,
                    yValues: usageModel.UsageTimes)
                .SetXAxis("Time of Day")
                .SetYAxis("Usage Time")
                .Write();

            return null;
        }

        public ActionResult GetDeviceModelsPieChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "pie",
                    xValue: usageModel.DeviceTypes,
                    yValues: usageModel.NumbersOfDevices)
                .SetXAxis("Device Type")
                .SetYAxis("Number of Devices")
                .Write();

            return null;
        }

        public ActionResult GetDownloadsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "line",
                    xValue: usageModel.Months,
                    yValues: usageModel.Downloads)
                .SetXAxis("Months")
                .SetYAxis("Number of App Downloads")
                .Write();

            return null;
        }

        public ActionResult GetLoginsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "bar",
                    xValue: usageModel.Months,
                    yValues: usageModel.Logins)
                .SetXAxis("Months")
                .SetYAxis("Number of App Logins")
                .Write();

            return null;
        }

        #endregion

        #region Resources Charts

        public ActionResult GetTestStripUsageChart()
        {
            var resourceModel = new ResourcesChartModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 600, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "bar",
                    xValue: resourceModel.Months,
                    yValues: resourceModel.TestStripUsages)
                .SetXAxis("Months")
                .SetYAxis("Number of Strips Used")
                .Write();

            return null;
        }

        public ActionResult GetHospitalPatientChart()
        {
            var resourceModel = new ResourcesChartModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 500, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "pie",
                    xValue: resourceModel.Clinics,
                    yValues: resourceModel.HospitalPatients)
                .SetXAxis("Clinics")
                .SetYAxis("Number of Patients Sent to Hospitals")
                .Write();

            return null;
        }

        public ActionResult GetClinicWorkersChart()
        {
            var resourceModel = new ResourcesChartModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 600, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "column",
                    xValue: resourceModel.Clinics,
                    yValues: resourceModel.ClinicWorkers)
                .SetXAxis("Clinic")
                .SetYAxis("Number of Individual Devices Registering Tests")
                .Write();

            return null;
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

        public ActionResult GetCrashesByTypeChart()
        {
            var crashModel = new CrashChartModel();
            crashModel = DataBackend.Instance.GetCrashData();

            var key = new Chart(width: 300, height: 400)
                .AddSeries(
                    chartType: "column",
                    xValue: crashModel.CrashTypes,
                    yValues: crashModel.CrashesByType)
                 .SetXAxis("Crash Type")
                 .SetYAxis("Total Crashes")
                 .Write();

            return null;
        }

        public ActionResult GetCrashesByDeviceTypeChart()
        {
            var crashModel = new CrashChartModel();
            crashModel = DataBackend.Instance.GetCrashData();

            var key = new Chart(width:300, height: 400)
                .AddSeries(
                    chartType: "pie",
                    xValue: crashModel.DeviceTypes,
                    yValues: crashModel.NumbersOfDevices)
                .SetXAxis("Device Model")
                .SetYAxis("Total Crashes")
                .Write();

            return null;
        }

        public ActionResult UpdateCrashChartTimeOption(CrashChartModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateCrashTimeOptionString(model.TimeOptionString);

                var crashModel = new CrashChartModel();

                crashModel = DataBackend.Instance.GetCrashData();

                return View("CrashReport", crashModel);
            }

            return View("Crash Report", model);
        }
        #endregion

        #region Home Charts

        public ActionResult GetBilirubinLevelChart()
        {
            var homeModel = new HomeChartModel();
            homeModel = DataBackend.Instance.GetHomeData();
            int num = homeModel.TimeOption;

            var key = new Chart(width: 1100, height: 400, theme: GetTheme())
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[0],
                    xValue: homeModel.Timeframe[num],
                    yValues: homeModel.BilirubinData[0])
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[1],
                    xValue: homeModel.Timeframe[num],
                    yValues: homeModel.BilirubinData[1])
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[2],
                    xValue: homeModel.Timeframe[num],
                    yValues: homeModel.BilirubinData[2])
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[3],
                    xValue: homeModel.Timeframe[num],
                    yValues: homeModel.BilirubinData[3])
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[4],
                    xValue: homeModel.Timeframe[num],
                    yValues: homeModel.BilirubinData[4])
                .SetXAxis("Time")
                .SetYAxis("Number of Tests Taken")
                .AddLegend()
                .Write();

            return null;
        }

        public ActionResult GetClinicBilirubinLevelChart()
        {
            var homeModel = new HomeChartModel();
            homeModel = DataBackend.Instance.GetHomeData();
            int num = homeModel.ClinicOption;

            var key = new Chart(width: 400, height: 550, theme: GetTheme())
                .AddSeries(
                    chartType: "column",
                    xValue: homeModel.ConvertDataToString(homeModel.BilirubinLevels),
                    yValues: homeModel.BilirubinData[num])
                .SetXAxis("Clinic " + homeModel.Clinics[num])
                .SetYAxis("Bilirubin Levels (%)")
                .Write();

            return null;
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

                var homeModel = new HomeChartModel();

                homeModel = DataBackend.Instance.GetHomeData();

                return View("Index", homeModel);
            }

            return View("Resources", model);
        }



        #endregion

        #region Photo Charts
        public ActionResult GetPhotosTakenByTimeChart()
        {
            var photoModel = new PhotoChartModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "line",
                    xValue: photoModel.Weeks,
                    yValues: photoModel.PhotosTakenByTime)
                .SetXAxis("Weeks")
                .SetYAxis("Total Photos Taken")
                .Write();

            return null;
        }

        public ActionResult GetSuccessfulFailedPhotosTaken()
        {
            var photoModel = new PhotoChartModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "line",
                    name: "Successful Photos",
                    xValue: photoModel.Days,
                    yValues: photoModel.SuccessfulPhotosTaken)
                .AddSeries(
                    chartType: "line",
                    name: "Failed Photos",
                    xValue: photoModel.Days,
                    yValues: photoModel.FailedPhotosTaken)
                .SetXAxis("Days")
                .SetYAxis("Total Photos Taken")
                .Write();

            return null;
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