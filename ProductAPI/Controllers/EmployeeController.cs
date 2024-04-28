using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly BankContext _context;
        public EmployeeController(BankContext bankContext)
        {
            _context = bankContext;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees; 

        }

        [HttpPost("{id}")]
        public IActionResult AddEmployee(int id, AddEmployee form)
        {
            var newEmployee = new Employee()
            {
                Name = form.Name,
                CivilId = form.CivilId,
                Position = form.Position,
                BankBranch = _context.BankBranches.Find(id),
            };
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = newEmployee.Id });
        }

        [HttpPatch("{id}")]
        public IActionResult EditEmployee(int id, AddEmployee req)
        {
            var employee = _context.Employees.Find(id);
            employee.Name = req.Name;
            employee.CivilId = req.CivilId;
            employee.Position = req.Position;

            _context.SaveChanges();

            return Created(nameof(Details), new { Id = employee.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok();
        }


        [HttpGet("{id}")]
        public ActionResult <EmployeeResponse> Details(int id) 
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            var response = new EmployeeResponse
            {
                Name = employee.Name,
                CivilId = employee.CivilId,
               Position = employee.Position,

            };
            return Ok(response);

        }
    }
}
