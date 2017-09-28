using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDelivery.Models
{
    public class OrderFood
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
    }
}