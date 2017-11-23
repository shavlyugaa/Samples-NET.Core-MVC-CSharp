﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Export_and_Print_Report_from_Code.Models;
using Stimulsoft.Report;
using System.Data;
using Stimulsoft.Report.Mvc;

namespace Export_and_Print_Report_from_Code.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private StiReport GetReport()
        {
            string reportPath = StiMvcHelper.MapPath(this, "Reports/TwoSimpleLists.mrt");
            var report = new StiReport();
            report.Load(reportPath);

            string dataPath = StiMvcHelper.MapPath(this, "Reports/Data/Demo.xml");
            var data = new DataSet("Demo");
            data.ReadXml(dataPath);
            report.RegData(data);

            return report;
        }

        public IActionResult PrintPdf()
        {
            StiReport report = this.GetReport();
            return StiMvcReportResponse.PrintAsPdf(report);
        }

        public IActionResult PrintHtml()
        {
            StiReport report = this.GetReport();
            return StiMvcReportResponse.PrintAsHtml(report);
        }

        public IActionResult ExportPdf()
        {
            StiReport report = this.GetReport();
            return StiMvcReportResponse.ResponseAsPdf(report);
        }

        public IActionResult ExportHtml()
        {
            StiReport report = this.GetReport();
            return StiMvcReportResponse.ResponseAsHtml(report);
        }

        public IActionResult ExportXls()
        {
            StiReport report = this.GetReport();
            return StiMvcReportResponse.ResponseAsXls(report);
        }
    }
}
