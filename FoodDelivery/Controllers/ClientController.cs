using FoodDelivery.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace FoodDelivery.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        DeliveryContext db = new DeliveryContext();

        [HttpGet]
        [Route("get/")]
        public async Task<IHttpActionResult> Get()
        {
            var record = await db.Clients.ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var record = await db.Clients.FirstAsync(r => r.ClientId == id);
            if (record == null)
                return NotFound();
            else return Ok(record);
        }


        [HttpPost]
        [Route("add/")]
        public async Task<IHttpActionResult> Add([FromBody] Client cl)
        {
            if (cl != null)
            {
                db.Clients.Add(cl);
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPut]
        [Route("edit/")]
        public async Task<IHttpActionResult> Edit([FromBody] Client cl)
        {
            if (cl!=null)
            {
                db.Entry(cl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
