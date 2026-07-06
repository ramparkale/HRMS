using Microsoft.AspNetCore.Mvc;
using HRMS.DTO;
using Microsoft.AspNetCore.Authorization;

namespace HRMS.Controllers
{
    [Route("api/payroll")]
    [ApiController]
    [Authorize(Roles = "Admin,HR")]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollRepository _repository;

        public PayrollController(IPayrollRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GeneratePayroll(GeneratePayrollDto dto)
        {
            await _repository.GeneratePayrollAsync(dto.EmployeeId, dto.Month, dto.Year);
            return Ok("Payroll generated successfully");
        }
    }

}
