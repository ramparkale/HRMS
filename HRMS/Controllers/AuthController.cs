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
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x =>
                    x.Username == dto.username &&
                    x.PasswordHash == dto.password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            var permissions = await (
                from rp in _context.RolePermissions
                join p in _context.Permissions
                    on rp.PermissionId equals p.PermissionId
                where rp.RoleId == user.RoleId
                      && rp.IsAllowed
                      && p.IsActive
                select p.PermissionCode
            ).ToListAsync();

            var response = new LoginResponseDto
            {
                Token = token,
                UserId = user.UserId,
                username = user.Username,
                Role = user.Role.RoleName,
                Permissions = permissions
            };

            return Ok(response);
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok("Authorized User");
        }  
    }
}
