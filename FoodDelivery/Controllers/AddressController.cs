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
        private DeliveryContext _db;

        public AddressController()
        {
            _db = new DeliveryContext();
        }

        [HttpGet]
        [Route("get/")]
        public async Task<IHttpActionResult> Get()
        {
            var record = await _db.Addressess.ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpGet]
        [Route("get/client/{id}")]
        public async Task<IHttpActionResult> GetByClient(int id)
        {
            var record = await _db.Addressess.Where(r => r.ClientId == id).ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }
        
        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var record = await _db.Addressess.FirstAsync(r => r.AddressId == id);
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
                _db.Addressess.Add(ad);
                await _db.SaveChangesAsync();
                return Ok(_db.Addressess.OrderByDescending(p => p.AddressId)
                    .FirstOrDefault().AddressId);
            }
            else return BadRequest();
        }

        [HttpPut]
        [Route("edit/")]
        public async Task<IHttpActionResult> Edit([FromBody] Address ad)
        {
            if (ad != null)
            {
                _db.Entry(ad).State = EntityState.Modified;
                await _db.SaveChangesAsync();
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
                _db.Entry(ad).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

    }
}
