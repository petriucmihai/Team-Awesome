using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using JaunDetect.Models;
using JaunDetect.Backend_Data;

namespace JaunDetect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

            return View(resourceModel);
        }

        public ActionResult CrashReport()
        {
            ViewBag.Message = "Crash Reports";

            return View();
        }

        public ActionResult CustomQuery()
        {
            ViewBag.Message = "Custom Query";

            var queryModel = new QueryViewModel();
            queryModel = QueryBackend.Instance.GetQuery();

            return View(queryModel);
        }

        public ActionResult QueryResults(QueryViewModel queryModel)
        {
            ViewBag.Message = "Query Results";
            return View("CustomQuery", queryModel);
        }

        public ActionResult Photos()
        {
            ViewBag.Message = "Failed Photo Gallery";

            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult GetTestStripUsageChart()
        {
            var resourceModel = new ResourcesChartModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "bar",
                    xValue: resourceModel.Months,
                    yValues: resourceModel.TestStripUsages)
                //.AddTitle("Testing Strips Used")
                .SetXAxis("Months")
                .SetYAxis("Number of Strips Used")
                .Write();

            return null;
        }

        public ActionResult GetHospitalPatientChart()
        {
            var resourceModel = new ResourcesChartModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "pie",
                    xValue: resourceModel.Clinics,
                    yValues: resourceModel.HospitalPatients)
                .SetXAxis("Clinics")
                .SetYAxis("Number of Patients Sent to Hospitals")
                .Write();

            return null;
        }

        public ActionResult GetCommonUsageTimesChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400)
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

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "pie",
                    xValue: usageModel.DeviceTypes,
                    yValues: usageModel.NumbersOfDevices)
                .SetXAxis("Device Type")
                .SetYAxis("Number of Devices")
                .AddLegend()
                .Write();

            return null;
        }

        public ActionResult GetDownloadsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400)
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

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "bar",
                    xValue: usageModel.Months,
                    yValues: usageModel.Logins)
                .SetXAxis("Months")
                .SetYAxis("Number of App Logins")
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

        public ActionResult GetCrashesByTimeChart()
        {
            var crashModel = new CrashChartModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "column",
                    xValue: crashModel.Days,
                    yValues: crashModel.CrashesByTime)
                .SetXAxis("Day")
                .SetYAxis("Total Crashes")
                .Write();

            return null;
        }

        public ActionResult GetCrashesByTypeChart()
        {
            var crashModel = new CrashChartModel();

            var key = new Chart(width: 600, height: 400)
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

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "pie",
                    xValue: crashModel.DeviceTypes,
                    yValues: crashModel.NumbersOfDevices)
                .SetXAxis("Device Model")
                .SetYAxis("Total Crashes")
                .Write();

            return null;
        }

        public ActionResult GetBilirubinLevelChart()
        {
            var homeModel = new HomeChartModel();
            int num = 0;

            var key = new Chart(width: 900, height: 400)
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
                    xValue: homeModel.Timeframe[homeModel.TimeOption],
                    yValues: homeModel.BilirubinData[2])
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[3],
                    xValue: homeModel.Timeframe[homeModel.TimeOption],
                    yValues: homeModel.BilirubinData[3])
                .AddSeries(
                    chartType: "column",
                    name: homeModel.Clinics[4],
                    xValue: homeModel.Timeframe[homeModel.TimeOption],
                    yValues: homeModel.BilirubinData[4])
                .SetXAxis("Months")
                .SetYAxis("Bilirubin Level (%)")
                .AddLegend()
                .Write();

            return null;
        }
    }
}