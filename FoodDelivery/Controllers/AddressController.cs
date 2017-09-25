using FoodDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDelivery.Controllers
{
    public class AddressController : ApiController
    {
        DeliveryContext db = new DeliveryContext();

        [HttpGet]
        public List<Address> Get()
        {
            return db.Addressess.ToList();
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Address adr)
        {
            if (adr != null)
            {
                db.Addressess.Add(adr);
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
