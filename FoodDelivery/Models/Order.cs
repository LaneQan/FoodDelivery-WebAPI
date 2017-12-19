using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDelivery.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
        public long OrderTime { get; set; }
        public float Cost { get; set; }
        public string PhoneNumber { get; set; }
        public List<Food> FoodList { get; set; }
    }
}