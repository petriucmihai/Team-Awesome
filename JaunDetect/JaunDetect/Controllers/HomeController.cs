using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}