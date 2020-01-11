using System;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
