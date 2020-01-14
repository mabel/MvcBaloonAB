using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Baloon_AB.Models;

namespace Baloon_AB.ViewModels
{
    public class ReportViewModel
    {
        public Project ThisProject { get; set; }
        public List<OrderRow> Rows { get; set; }
    }
}
