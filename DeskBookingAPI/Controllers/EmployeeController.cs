using DeskBookingAPI.Data;
using DeskBookingAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly DeskBookingContext _context;

        public EmployeeController(DeskBookingContext context)
        {
            _context = context;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.Employees.ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Employees.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return NotFound();
            return new JsonResult(item);

        }

        [HttpGet("byCompany/{companyId}")]
        public IEnumerable GetByCompanyId(int companyId)
        {
            return from employee in _context.Employees
                   where employee.CompanyId == companyId
                   select employee;
        }


        [HttpGet("{empId}/favDesk")]
        public IActionResult GetFavDesk(int empId)
        {
            var favDesk = _context.Bookings.Where(b => b.EmployeeId == empId).
                GroupBy(b => b.DeskId).
                OrderBy(gr => -gr.Count()).
                Select(gr => new FavDeskDTO()
                {
                    deskId = gr.Key,
                    numberOfBookings = gr.Count(),
                }).First();
            return new ObjectResult(favDesk);
        }


        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Create([FromBody] Employee item)
        {
            if (item == null)
                return BadRequest();
            _context.Employees.Add(item);
            _context.SaveChanges();
            return new JsonResult(item);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeDTO item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var employee = _context.Employees.FirstOrDefault(t => t.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = item.Name ?? employee.Name;
            employee.Email=item.Email ?? employee.Email;
            employee.Role= item.Role ?? employee.Role;
            employee.CompanyId=item.CompanyId ?? employee.CompanyId;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(t => t.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
