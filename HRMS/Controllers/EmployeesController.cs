using HRMS.DTO;
using HRMS.DTOs;
using HRMS.Models;
using HRMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HRMSDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(
            HRMSDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees
                //.Include(x => x.Department)
                //.Include(x => x.Designation)
                .Select(x => new EmployeeProfileDto
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeCode = x.EmployeeCode,
                    FullName = x.FirstName + " " + x.LastName,
                    //DepartmentName = x.Department.DepartmentName,
                    //DesignationName = x.Designation.DesignationName,
                    Email = x.Email,
                    //PhoneNumber = x.PhoneNumber,
                    //JoiningDate = x.JoiningDate,
                    //Salary = x.Salary
                })
                .ToListAsync();

            return Ok(employees);
        }

        // GET: api/employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _context.Employees
                //.Include(x => x.Department)
                //.Include(x => x.Designation)
                .Where(x => x.EmployeeId == id)
                .Select(x => new EmployeeProfileDto
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeCode = x.EmployeeCode,
                    FullName = x.FirstName + " " + x.LastName,
                   // DepartmentName = x.Department.DepartmentName,
                    //DesignationName = x.Designation.DesignationName,
                    Email = x.Email,
                   // PhoneNumber = x.PhoneNumber,
                   // JoiningDate = x.JoiningDate,
                   // Salary = x.Salary
                })
                .FirstOrDefaultAsync();

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                EmployeeCode = dto.EmployeeCode,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
               // Gender = dto.Gender,
                //DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                //PhoneNumber = dto.PhoneNumber,
                //Address = dto.Address,
                //JoiningDate = dto.JoiningDate,
                //Salary = dto.Salary,
                //DepartmentId = dto.DepartmentId,
                DesignationId = dto.DesignationId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // DELETE: api/employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees
                .FindAsync(id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok("Employee deleted successfully");
        }
    }
}
