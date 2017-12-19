using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private DeliveryContext _db;

        public OrderController()
        {
            _db = new DeliveryContext();
        }


        [HttpGet]
        [Route("get/")]
        public async Task<IHttpActionResult> Get()
        {
            var record = await _db.Orders.ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpPost]
        [Route("add/")]
        public async Task<IHttpActionResult> Add([FromBody] Order order)
        {
            if (order != null)
            {
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }


        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var record = await _db.Orders.Where(r => r.ClientId == id).ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }


        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id != null)
            {
                Order order = _db.Orders
                    .Where(o => o.OrderId == id)
                    .FirstOrDefault();

                _db.Orders.Remove(order);
                _db.SaveChanges();
                await _db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
