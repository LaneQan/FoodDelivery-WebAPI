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
    [RoutePrefix("api/food")]
    public class FoodController : ApiController
    {
        private DeliveryContext _db;

        public FoodController()
        {
            _db = new DeliveryContext();
        }

        [HttpGet]
        [Route("get/{type}")]
        public async Task<IHttpActionResult> Get(string type)
        {
            var record = await _db.Foods.Where(r => r.Type == type && r.Order==null).ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpPost]
        [Route("add/")]
        public async Task<IHttpActionResult> Add([FromBody] Food fd)
        {
            if (fd != null)
            {
                _db.Foods.Add(fd);
                await _db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id != null)
            {
                Food food = _db.Foods
                    .Where(o => o.FoodId == id)
                    .FirstOrDefault();

                _db.Foods.Remove(food);
                _db.SaveChanges();
                await _db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
