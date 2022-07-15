using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly DeskBookingContext _context;

        public BookingController(DeskBookingContext context)
        {
            _context = context;
        }

        [HttpGet("byEmployee/{employeeId}")]
        public IEnumerable GetByEmployeeId(int employeeId, [FromQuery] bool excludePastDue=false)
        {
            //return from booking in _context.Bookings
            //       where booking.EmployeeId == employeeId
            //       select booking;

            if(excludePastDue)
            {
                return _context.Bookings.Where(b => b.EmployeeId == employeeId && (DateTime.Compare(b.Date, DateTime.UtcNow) >= 0));
            }
            return _context.Bookings.Where(b=>b.EmployeeId == employeeId);

        }

        [HttpPost]
        public IActionResult Create([FromBody] Booking item)
        {
            if (item == null)
                return BadRequest();
            var employee=_context.Employees.FirstOrDefault(x => x.Id == item.EmployeeId);
            var desk=_context.Desks.Include(d=>d.CompanyRoom).FirstOrDefault(x => x.Id == item.DeskId);
            if (employee.CompanyId == desk.CompanyRoom.CompanyId)
            {
                _context.Bookings.Add(item);
                _context.SaveChanges();
                return new JsonResult(item);
            }
            else
                return BadRequest("You cannot book a desk at another company");
        }
    }
}
