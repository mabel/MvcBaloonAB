using System;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Amount { get; set; }
    }
}
