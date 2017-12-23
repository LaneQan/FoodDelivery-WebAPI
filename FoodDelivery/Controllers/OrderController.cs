using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FoodDelivery.Models;
using Newtonsoft.Json;

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
            var orders = await _db.Orders.Include(x => x.FoodList).ToListAsync();
            return Ok(orders);
        }


        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] object json)
        {
            Order order = JsonConvert.DeserializeObject<Order>(json.ToString());
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
            var orders = await _db.Orders.Where(r => r.ClientId == id).Include(x => x.FoodList).ToListAsync();
            return Ok(orders);
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
