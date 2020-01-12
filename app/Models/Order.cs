using System;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class Order
    {
        //public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
