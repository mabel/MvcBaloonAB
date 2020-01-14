using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Baloon_AB.Models;
using Baloon_AB.Data;

namespace Baloon_AB.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        public IActionResult Bad()
        {
            return View();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Add([FromServices] AppDbContext context, string project_name, string user_name)
        {
            if(project_name == null) return RedirectToAction("List");
            Project proj = new Project();
            proj.Name = project_name;
            proj.UserId = user_name;
            proj.InitDate = DateTime.Now;
            if (!TryValidateModel(proj, nameof(Project)))
            {
                return RedirectToAction("Bad");
            }
            context.Projects.Add(proj);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Del([FromServices] AppDbContext context, int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Project proj = context.Projects.Find(id);
            if (proj == null)
            {
                return NotFound();
            }
            context.Projects.Remove(proj);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit([FromServices] AppDbContext context, int? id, string Name, DateTime InitDate)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Project proj = context.Projects.Find(id);
            if (proj == null)
            {
                return NotFound();
            }
            proj.Name = Name;
            proj.InitDate = InitDate;
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Item([FromServices] AppDbContext context, int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Project proj = context.Projects.Find(id);
            if (proj == null)
            {
                return NotFound();
            }
            IQueryable<OrderRow> orders = context.OrderRows
                .Where(o => o.ProjectId == id);
            ViewData["Orders"] = orders.ToList();
            return View(proj);
        }
    
        public IActionResult List([FromServices] AppDbContext context)
        {
            IQueryable<Project> projects = context.Projects
                .Where(p => p.UserId == User.Identity.Name);
            return View(projects.ToList());
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
