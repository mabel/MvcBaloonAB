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
    [Route("[controller]/{proj}/{prod}/[action]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        public IActionResult Add([FromServices] AppDbContext context, int proj, int prod, int amount)
        {
            IQueryable<Order> orders = context.Orders
                .Where(o => o.ProjectId == proj && o.ProductId == prod);
            if(orders.Count() == 0){
                Order order = new Order();
                order.ProjectId = proj;
                order.ProductId = prod;
                order.Amount = amount;
                context.Orders.Add(order);
            }
            else {
                Order order = orders.ToList().ElementAt(0);
                order.Amount = amount;
            }
            context.SaveChanges();
            return Redirect("/project/item/" + proj);
        }

        public IActionResult Del([FromServices] AppDbContext context, int proj, int prod)
        {
            IQueryable<Order> orders = context.Orders
                .Where(o => o.ProjectId == proj && o.ProductId == prod);
            if(orders.Count() > 0){
                Order order = orders.ToList().ElementAt(0);
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return Redirect("/project/item/" + proj);
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
