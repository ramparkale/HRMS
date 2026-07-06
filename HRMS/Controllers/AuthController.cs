using HRMS.DTO;
using HRMS.Helper;
using HRMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HrmsDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthController(HrmsDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var passwordHash = PasswordHelper.HashPassword(dto.password);

            var user = await _context.Users
                .Include(u => u.Role).FirstOrDefaultAsync(x => x.Username == dto.username && x.PasswordHash == dto.password);
            //.FirstOrDefaultAsync(u =>
            //    u.Username == dto.username &&
            //    u.PasswordHash == passwordHash &&
            //    u.IsActive);

            //var user = _context.Users
            //   .FirstOrDefault(x => x.Username == dto.Username && x.Password == dto.Password);

            //if (user == null)
            //    return Unauthorized("Invalid credentials");

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                role = user.Role.RoleName
            });
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok("Authorized User");
        }  
    }
}
