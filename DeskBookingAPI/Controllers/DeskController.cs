using DeskBookingAPI.Data;
using DeskBookingAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskController : Controller
    {
        private readonly DeskBookingContext _context;

        public DeskController(DeskBookingContext context)
        {
            _context = context;
        }
        // GET: api/<DeskController>
        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.Desks.ToList();
        }

        // GET api/<DeskController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Desks.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return NotFound();
            return new JsonResult(item);

        }

        [HttpGet("birouri")]
        public IEnumerable GetDesk()
        {
            var items = _context.Desks.Include(d => d.CompanyRoom).Select(d => new DeskDTO()
            {
                deskNumber = d.Number,
                isStanding = d.IsStanding ? "yes" : "no",
                roomFloor = d.CompanyRoom.Floor,
                roomName = d.CompanyRoom.Name,
                roomNumber = d.CompanyRoom.Number
            });
            return items;
        }

        // POST api/<DeskController>
        [HttpPost]
        public IActionResult Create([FromBody] Desk item)
        {
            if (item == null)
                return BadRequest();
            _context.Desks.Add(item);
            _context.SaveChanges();
            return new JsonResult(item);
        }

        // PUT api/<DeskController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Desk item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var desk = _context.Desks.FirstOrDefault(t => t.Id == id);
            if (desk == null)
            {
                return NotFound();
            }
            desk.Number = item.Number;
            desk.IsStanding = item.IsStanding;
            desk.CompanyRoomId = item.CompanyRoomId;
            _context.Desks.Update(desk);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<DeskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var desk = _context.Desks.FirstOrDefault(t => t.Id == id);
            if (desk == null)
            {
                return NotFound();
            }

            _context.Desks.Remove(desk);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
