using FoodDelivery.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace FoodDelivery.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        private DeliveryContext _db;

        public ClientController()
        {
            _db = new DeliveryContext();
        }

        [HttpGet]
        [Route("get/")]
        public async Task<IHttpActionResult> Get()
        {
            var record = await _db.Clients.ToListAsync();
            if (record == null)
                return NotFound();
            else return Ok(record);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var record = await _db.Clients.FirstAsync(r => r.ClientId == id);
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
                _db.Clients.Add(cl);
                await _db.SaveChangesAsync();
                return Ok(_db.Clients.OrderByDescending(p => p.ClientId)
                    .FirstOrDefault().ClientId);
            }
            else return BadRequest();
        }

        [HttpPut]
        [Route("edit/")]
        public async Task<IHttpActionResult> Edit([FromBody] Client cl)
        {
            if (cl!=null)
            {
                _db.Entry(cl).State = EntityState.Modified;
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
                Client cl = _db.Clients
                    .Where(o => o.ClientId == id)
                    .FirstOrDefault();

                _db.Clients.Remove(cl);
                _db.SaveChanges();
                await _db.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
