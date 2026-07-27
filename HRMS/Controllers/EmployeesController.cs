using HRMS.DTOs;
using HRMS.Models;
using HRMS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // GET api/Employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _repository.GetAll();

            return Ok(employees);
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _repository.GetById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST api/Employee
        [HttpPost]
        //public async Task<IActionResult> Post(Employee employee)
        //{
        //    var result = await _repository.Add(employee);

        //    return Ok(result);
        //}

        public async Task<IActionResult> Post(EmployeeDTO dto)
        {
          
            var employee = new Employee
            {
                UserId = dto.UserId,
                EmployeeCode = dto.EmployeeCode,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
                DesignationId = dto.DesignationId,
                DateOfJoining = DateOnly.FromDateTime(dto.DateOfJoining),
                ManagerId = dto.ManagerId
            };

            var result = await _repository.Add(employee);

            return Ok(result);
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        //[HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmployeeDTO dto)
        {
            if (id != dto.EmployeeId)
                return BadRequest();

            var employee = new Employee
            {
                EmployeeId = dto.EmployeeId,
                UserId = dto.UserId,
                EmployeeCode = dto.EmployeeCode,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
                DesignationId = dto.DesignationId,
                DateOfJoining = DateOnly.FromDateTime(dto.DateOfJoining),
                ManagerId = dto.ManagerId,
                CreatedDate=dto.CreatedDate
            };

            var result = await _repository.Update(employee);

            return Ok(result);
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}