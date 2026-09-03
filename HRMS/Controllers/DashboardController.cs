using HRMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            try
            {
                var data = await _service.GetDashboardAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving dashboard data: {ex.Message}", ex);
            }
        }
    }
}
