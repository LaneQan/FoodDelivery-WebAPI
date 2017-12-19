using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FoodDelivery.Models;

namespace FoodDelivery.Models
{
     class DeliveryContext : DbContext
    {
        public DeliveryContext(): base("DbConnection") { }

        public DbSet<Address> Addressess { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}