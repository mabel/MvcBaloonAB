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
    [Route("[controller]/{proj}/[action]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
    
        public IActionResult List([FromServices] AppDbContext context, int proj)
        {
            ViewData["ProjectId"] = proj;    
            List<int> ToExclude = context.Orders
                .Where(o => o.ProjectId == proj)
                .Select(o => o.ProductId).ToList();
            IQueryable<Product> products = context.Products
                .Where(p => !(ToExclude.Contains(p.Id)));
            return View(products.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
