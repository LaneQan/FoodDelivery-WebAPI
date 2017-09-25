using FoodDelivery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace FoodDelivery.Controllers
{
    public class ClientController : ApiController
    {
        DeliveryContext db = new DeliveryContext();

        [HttpGet]
        public List<Client> Get()
        {
            return db.Clients.ToList();
        }

        [HttpGet]
        public Client Get(int Id)
        {
            return db.Clients.First(r => r.ClientId == Id);
        }


        [HttpPost]
        public IHttpActionResult Add([FromBody] Client cl)
        {
            if (cl != null)
            {
                db.Clients.Add(cl);
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Edit([FromBody] Client cl)
        {
            if (cl!=null)
            {
                db.Entry(cl).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
