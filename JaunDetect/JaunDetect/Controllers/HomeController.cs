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

            var resourceModel = new ResourcesViewModel();

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

            return View();
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
            var resourceModel = new ResourcesViewModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "bar",
                    legend: "Test Strips Used",
                    xValue: resourceModel.Months,
                    yValues: resourceModel.TestStripUsages)
                .Write();

            return null;
        }

        public ActionResult GetHospitalPatientChart()
        {
            var resourceModel = new ResourcesViewModel();

            resourceModel = DataBackend.Instance.GetResources();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "pie",
                    legend: "Highest-Percentage Cases by Clinic",
                    xValue: resourceModel.Clinics,
                    yValues: resourceModel.HospitalPatients)
                .Write();

            return null;
        }

        public ActionResult GetCommonUsageTimesChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "column",
                    legend: "CommonUsageTimes",
                    xValue: usageModel.TimesOfDay,
                    yValues: usageModel.UsageTimes)
                .Write();

            return null;
        }

        public ActionResult GetDeviceModelsPieChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "pie",
                    legend: "Device Models",
                    xValue: usageModel.DeviceTypes,
                    yValues: usageModel.NumbersOfDevices)
                .Write();

            return null;
        }

        public ActionResult GetDownloadsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "line",
                    legend: "Downloads Per Month",
                    xValue: usageModel.Months,
                    yValues: usageModel.Downloads)
                .Write();

            return null;
        }

        public ActionResult GetLoginsPerMonthChart()
        {
            var usageModel = new UsageViewModel();

            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "bar",
                    legend: "Logins Per Month",
                    xValue: usageModel.Months,
                    yValues: usageModel.Logins)
                .Write();

            return null;
        }

        [HttpPost]
        public ActionResult UpdatePrice(ResourcesViewModel model)
        {
            if (ModelState.IsValid)
            {
                DataBackend.Instance.UpdateStripPrice(model.TestStripPrice);

                var resourceModel = new ResourcesViewModel();

                resourceModel = DataBackend.Instance.GetResources();

                return View("Resources", resourceModel);
            }

            return View("Resources", model);
        }
    }
}