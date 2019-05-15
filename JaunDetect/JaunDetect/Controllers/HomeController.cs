using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using JaunDetect.Models;

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

            return View();
        }

        public ActionResult Resources()
        {
            ViewBag.Message = "Resources and Budgeting";

            return View();
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

        public ActionResult GetTestStripUsageChart()
        {
            var resourceModel = new ResourcesDataModel();

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
            var resourceModel = new ResourcesDataModel();

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
    }
}