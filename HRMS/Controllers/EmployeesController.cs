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
        public async Task<IActionResult> Post(Employee employee)
        {
            var result = await _repository.Add(employee);

            return Ok(result);
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

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