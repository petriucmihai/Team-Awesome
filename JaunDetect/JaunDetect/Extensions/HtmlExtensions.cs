using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaunDetect.Extensions
{
    public static class HtmlExtensions
    {
        public static string IsActive(this HtmlHelper htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();
            var routeController = routeData.Values["controller"].ToString();

            return (controller == routeController && action == routeAction) ? "active" : "";
        }
    }
}