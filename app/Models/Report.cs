using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class Report
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectInitDate { get; set; }
        public List<OrderRow> Rows { get; set; }
    }
}
