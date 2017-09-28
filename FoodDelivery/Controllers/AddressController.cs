using FoodDelivery.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace FoodDelivery.Controllers
{
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        DeliveryContext db = new DeliveryContext();

        [HttpGet]
        [Route("get/")]
        public async Task<IHttpActionResult> Get()
        {
            var record = await db.Addressess.ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpGet]
        [Route("get/client/{id}")]
        public async Task<IHttpActionResult> GetByClient(int id)
        {
            var record = await db.Addressess.Where(r => r.ClientId == id).ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }
        
        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var record = await db.Addressess.FirstAsync(r => r.AddressId == id);
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpPost]
        [Route("add/")]
        public async Task<IHttpActionResult> Add([FromBody] Address ad)
        {
            if (ad != null)
            {
                db.Addressess.Add(ad);
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPut]
        [Route("edit/")]
        public async Task<IHttpActionResult> Edit([FromBody] Address ad)
        {
            if (ad != null)
            {
                db.Entry(ad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }
        [HttpDelete]
        [Route("delete/")]
        public async Task<IHttpActionResult> Delete([FromBody] Address ad)
        {
            if (ad != null)
            {
                db.Entry(ad).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

    }
}
