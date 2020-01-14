using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Baloon_AB.Data;
using Baloon_AB.Models;
using Baloon_AB.ViewModels;

namespace Baloon_AB.Controllers
{
    [Authorize(Roles="Admin")]
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] AppDbContext context)
        {
            List<ReportViewModel> reports = new List<ReportViewModel>();
            List<Project> projects = context.Projects.ToList();
            foreach(var project in projects){
                var report = new ReportViewModel();
                report.ThisProject = project;
                report.Rows = context.OrderRows
                    .Where(o => o.ProjectId == project.Id).ToList();
                reports.Add(report);
            }
            return View(reports);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
