using System;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class OrderRow
    {
        public int ProjId { get; set; }
        public int ProdId { get; set; }
        public int Amount { get; set; }
        public string Project { get; set; }
        public string Product { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
    }
}
