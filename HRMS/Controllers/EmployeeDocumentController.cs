using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDocumentController : ControllerBase
    {
        private readonly HRMSDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EmployeeDocumentController(
            HRMSDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(
            [FromForm] UploadEmployeeDocumentDto dto)
        {
            if (dto.File == null)
                return BadRequest();

            var folder = Path.Combine(
                _environment.WebRootPath,
                "EmployeeDocuments");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() +
                           Path.GetExtension(dto.File.FileName);

            var filePath = Path.Combine(folder, fileName);

            using var stream = new FileStream(
                filePath, FileMode.Create);

            await dto.File.CopyToAsync(stream);

            var document = new EmployeeDocument
            {
                EmployeeId = dto.EmployeeId,
                DocumentType = dto.DocumentType,
                FileName = dto.File.FileName,
                FilePath = fileName
            };

            //_context.EmployeeDocuments.Add(document);
            await _context.SaveChangesAsync();

            return Ok(document);
        }
    }
}
