using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly HrmsDbContext _context;

        public DepartmentController(HrmsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Departments.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                DepartmentName = dto.DepartmentName
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateDepartmentDto dto)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            department.DepartmentName = dto.DepartmentName;
            department.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}
