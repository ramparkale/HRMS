using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class DesignationController : ControllerBase
{
    private readonly HRMSDbContext _context;

    public DesignationController(HRMSDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        return Ok(await _context.Designations.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDesignationDto dto)
    {
        var data = new Designation
        {
            DesignationName = dto.DesignationName
        };

        _context.Designations.Add(data);
        await _context.SaveChangesAsync();

        return Ok(data);
    }
}