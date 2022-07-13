using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly DeskBookingContext _context;

        public CompanyController(DeskBookingContext context)
        {
            _context = context;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.Companies.ToList();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item=_context.Companies.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return NotFound();
            return new JsonResult(item);

        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Create([FromBody] Company item)
        {
            if (item == null)
                return BadRequest();
            _context.Companies.Add(item);
            _context.SaveChanges();
            return new JsonResult(item);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Company item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var company = _context.Companies.FirstOrDefault(t => t.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            company.Name=item.Name;
            company.Adress=item.Adress;
            _context.Companies.Update(company);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(t => t.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
