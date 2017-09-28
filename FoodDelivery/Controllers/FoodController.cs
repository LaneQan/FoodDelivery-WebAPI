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
        DeliveryContext db = new DeliveryContext();

        [HttpGet]
        [Route("get/{type}")]
        public async Task<IHttpActionResult> Get(string type)
        {
            var record = await db.Foods.Where(r => r.Type == type).ToListAsync();
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
                db.Foods.Add(fd);
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

        [HttpDelete]
        [Route("delete/")]
        public async Task<IHttpActionResult> Delete([FromBody] Food fd)
        {
            if (fd != null)
            {
                db.Entry(fd).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
