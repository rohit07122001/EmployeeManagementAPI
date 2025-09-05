using EmployeeManagementAPI1.Data;
using EmployeeManagementAPI1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EmployeeManagementAPI1.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext db;
        public EmployeeController(EmployeeDbContext context)
        { 
            this.db = context;
        }


        [HttpGet]
        [Route("api/Employee/GetEmployeesList")]
        public async Task<IActionResult> GetEmployeesList()
        {
            var employess = await db.EMployees.ToListAsync();
            return Ok(employess);
        }

        [HttpGet]
        [Route("api/Employee/GetEmployeesById")]
        public async Task<IActionResult> GetEmployeesById(int id)
        {
            var employess = await db.EMployees.FindAsync(id);
            if (employess == null)
            {
                return NotFound();
            }
            return Ok(employess);
        }

        [HttpPost]
        [Route("api/Employee/CreateEmployee")]

        public async Task<IActionResult> CreateEmployee(Employee obj)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            db.EMployees.Add(obj);
            await db.SaveChangesAsync();
            return Ok();    
        }

        [HttpPut]
        [Route("api/Employee/UpdateEmployee")]

        public async Task<IActionResult> UpdateEmployee(int id,Employee obj)
        {
            if(id != obj.Id)
            {
                return BadRequest("Employee id mismatched");
            }
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(obj);
        }


        [HttpDelete]
        [Route("api/Employee/DeleteEmployee")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employess = await db.EMployees.FindAsync(id);
            if (employess == null)
            {
                return NotFound();
            }
            db.EMployees.Remove(employess); 
            await db.SaveChangesAsync();
            return Ok();
        }

    }
}



