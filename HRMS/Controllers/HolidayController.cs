using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly HRMSDbContext _context;

        public HolidayController(HRMSDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Holidays.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHolidayDto dto)
        {
            var holiday = new Holiday
            {
                HolidayName = dto.HolidayName,
                HolidayDate = dto.HolidayDate,
                Description = dto.Description
            };

            _context.Holidays.Add(holiday);

            await _context.SaveChangesAsync();

            return Ok(holiday);
        }
    }
}
