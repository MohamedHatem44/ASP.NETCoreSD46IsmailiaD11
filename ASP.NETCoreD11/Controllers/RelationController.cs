using ASP.NETCoreD11.Context;
using ASP.NETCoreD11.DTOs.Employee;
using ASP.NETCoreD11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreD11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelationController(AppDbContext context)
        {
            _context = context;
        }
        /*------------------------------------------------------------------*/
        // Get By Id
        [HttpGet("/EmployeeV01/{id:int}")]
        public ActionResult<Employee> GetEmployeeByByIdV01([FromRoute] int id)
        {
            var employee = _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                return NotFound(new { Message = $"Employee with Id: {id} Not Found" });
            }
            return Ok(employee);
        }
        /*------------------------------------------------------------------*/
        // Get By Id
        [HttpGet("/EmployeeV02/{id:int}")]
        public ActionResult<Employee> GetEmployeeByByIdV02([FromRoute] int id)
        {
            var employee = _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                return NotFound(new { Message = $"Employee with Id: {id} Not Found" });
            }

            var employeeReadDto = new EmployeeReadDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.Name
            };

            return Ok(employeeReadDto);
        }
        /*------------------------------------------------------------------*/
        // Get By Id
        [HttpGet("/Department/{id:int}")]
        public ActionResult<Department> GetDepartmentById([FromRoute] int id)
        {
            var department = _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefault(e => e.Id == id);
            if (department is null)
            {
                return NotFound(new { Message = $"Department with Id: {id} Not Found" });
            }
            return Ok(department);
        }
        /*------------------------------------------------------------------*/
    }
}
