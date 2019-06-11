using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JaunDetect.Models;
using JaunDetect.Backend_Data;
using System.Web.Helpers;

namespace JaunDetect.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Index()
        {
            var homeModel = new HomeChartModel();

            homeModel = Backend.Instance.GetHomeData();

            return View(homeModel);
        }

        public ActionResult GuestResources()
        {
            var resourcesModel = new ResourcesChartModel();

            resourcesModel = Backend.Instance.GetResources();

            return View(resourcesModel);
        }

        public ActionResult GetBilirubinLevelChart()
        {
            var homeModel = new HomeChartModel();
            homeModel = Backend.Instance.GetHomeData();
            int num = homeModel.TimeOption;

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
                .SetXAxis("Months")
                .SetYAxis("Bilirubin Level (%)")
                .AddLegend()
                .Write();

            return null;
        }

        [HttpPost]
        public ActionResult UpdateHomeChartTimeOption(HomeChartModel model)
        {
            if (ModelState.IsValid)
            {
                Backend.Instance.UpdateTimeOptionString(model.TimeOptionString);

                var homeModel = new HomeChartModel();

                homeModel = Backend.Instance.GetHomeData();

                return View("Index", homeModel);
            }

            return View("Resources", model);
        }
    }


}