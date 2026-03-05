using ASP.NETCoreD11.Context;
using ASP.NETCoreD11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /*------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        /*------------------------------------------------------------------*/
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }
        /*------------------------------------------------------------------*/
        // Get All
        // IActionResult => Not Recommeded
        // ActionResult<T> => ActionResult<List<Employee>> => ActionResult<Result>
        // TypedResult<Ok<List<Employee>>, NotFound> StronglyTyped => Minimal APIs
        // public TypedResults<Ok<List<Employee>>, NotFound> GetAll()
        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }
        /*------------------------------------------------------------------*/
        // Get By Id
        [HttpGet("{id:int}")]
        // Get: /api/Employees/1    => Route
        // Get: /api/Employees?id=1 => QueryString
        public ActionResult<Employee> GetById([FromRoute] int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee is null)
            {
                return NotFound(new { Message = $"Employee with Id: {id} Not Found" });
            }
            return Ok(employee);
        }
        /*------------------------------------------------------------------*/
        // Get By Name
        [HttpGet("{name:alpha}")]
        public ActionResult<Employee> GetByName([FromRoute] string name)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Name == name);
            if (employee is null)
            {
                return NotFound(new { Message = $"Employee with Name: {name} Not Found" });
            }
            return Ok(employee);
        }
        /*------------------------------------------------------------------*/
        // Create V01
        [HttpPost]
        [Route("CreateV01")]
        public ActionResult<Employee> CreateV01([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // 400
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        /*------------------------------------------------------------------*/
        // Create V02
        [HttpPost]
        [Route("CreateV02")]
        public ActionResult CreateV02([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // 400
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            // 201 Created
            return Created();
        }
        /*------------------------------------------------------------------*/
        // Create V03
        [HttpPost]
        [Route("CreateV03")]
        public ActionResult CreateV03([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // 400
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            // 201 Created
            // Response Header Location => Test
            return Created("Test", employee);
        }
        /*------------------------------------------------------------------*/
        // Create V04
        [HttpPost]
        [Route("CreateV04")]
        public ActionResult CreateV04([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // 400
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            // 201 Created
            // Response Header Location => Full Url
            return CreatedAtAction("GetById", new { id = employee.Id }, employee);
        }
        /*------------------------------------------------------------------*/
        // Update V01
        [HttpPut]
        [Route("UpdateV01/{id:int}")]
        public ActionResult UpdateV01([FromRoute] int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (employee is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        /*------------------------------------------------------------------*/
        // Update V02
        [HttpPut]
        [Route("UpdateV02/{id:int}")]
        public ActionResult UpdateV02([FromRoute] int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (employee is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var employeeToUpdate = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeToUpdate is null)
            {
                // 404
                return NotFound();
            }

            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Age = employee.Age;
            employeeToUpdate.Salary = employee.Salary;
            _context.SaveChanges();

            return Ok(employee);
        }
        /*------------------------------------------------------------------*/
        // Delete
        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeToDelete is null)
            {
                // 404
                return NotFound();
            }
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
            return NoContent();
        }
        /*------------------------------------------------------------------*/
    }
}
