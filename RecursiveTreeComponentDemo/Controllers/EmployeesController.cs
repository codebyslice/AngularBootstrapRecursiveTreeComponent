using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeHierarchy.Models;
using Microsoft.AspNetCore.Cors;

namespace EmployeeHierarchy.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    public class EmployeesController : Controller
    {
        private readonly OrganizationContext _context;

        public EmployeesController(OrganizationContext context)
        {
            _context = context;
        }

      //  GET: api/Employees
      [HttpGet]
         public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var temp = await _context.Employee.ToListAsync();
            return temp;
        }
        [HttpGet("[action]")]
        public IEnumerable<Employee> GetEmployees()
        {
            Employee john = new Employee(1, "John A", null);
            Employee mike = new Employee(2, "Mike B", 1);
            Employee anagha = new Employee(4, "Anagha P", 2);
            Employee advith = new Employee(5, "Advith M", 2);
            Employee ram = new Employee(6, "Ram D", 4);
            Employee jack = new Employee(7, "Jack C", 4);
            Employee raj = new Employee(3, "Raj C", 1);

            john.Children = new List<Employee>() { mike, raj };
            mike.Children = new List<Employee>() { anagha, advith };
            anagha.Children = new List<Employee>() { ram, jack };

            List<Employee> employees = new List<Employee>(){
            john,mike,raj,anagha,advith,ram,jack
            };

            return employees.Where(x=>x.ManagerId==null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
