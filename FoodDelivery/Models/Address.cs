using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDelivery.Models
{
    public class Address
    {   
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public string AddressName { get; set; }
    }
}