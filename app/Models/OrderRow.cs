using System;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class OrderRow
    {
        public int ProjectId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public string Project { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
    }
}
