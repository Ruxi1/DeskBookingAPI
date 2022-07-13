using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRoomController : Controller
    {
        private readonly DeskBookingContext _context;

        public CompanyRoomController(DeskBookingContext context)
        {
            _context = context;
        }
        // GET: api/<CompanyRoomController>
        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.CompanyRooms.ToList();
        }

        // GET api/<CompanyRoomController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.CompanyRooms.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return NotFound();
            return new JsonResult(item);

        }

        // POST api/<CompanyRoomController>
        [HttpPost]
        public IActionResult Create([FromBody] CompanyRoom item)
        {
            if (item == null)
                return BadRequest();
            _context.CompanyRooms.Add(item);
            _context.SaveChanges();
            return new JsonResult(item);
        }

        // PUT api/<CompanyRoomController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyRoom item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var companyroom = _context.CompanyRooms.FirstOrDefault(t => t.Id == id);
            if (companyroom == null)
            {
                return NotFound();
            }
            companyroom.Name = item.Name;
            companyroom.CompanyId = item.CompanyId;
            companyroom.Floor=item.Floor;
            companyroom.Number= item.Number;
            _context.CompanyRooms.Update(companyroom);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<CompanyRoomController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var companyroom = _context.CompanyRooms.FirstOrDefault(t => t.Id == id);
            if (companyroom == null)
            {
                return NotFound();
            }

            _context.CompanyRooms.Remove(companyroom);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
