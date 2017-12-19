using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDelivery.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string Size { get; set; }
        public int CookingTime { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}