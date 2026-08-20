using Google.Apis.Auth;
using HRMS.DTO;
using HRMS.Helper;
using HRMS.Models;
using HRMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            try 
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
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

      
        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginDto dto)
        {
            try
            {
                //var payload = await GoogleJsonWebSignature.ValidateAsync(dto.Token);

                // C# - decode JWT payload (for debugging)
                var parts = dto.Token.Split('.');
                var payloadPadded = parts[1].PadRight(parts[1].Length + (4 - parts[1].Length % 4) % 4, '=');
                var payloadJson = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(payloadPadded));
                Console.WriteLine(payloadJson); // look for "aud"

                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[]
                      {
                        "526627649609-f4afdajneveffuffsdmtpjs3f88g4sbq.apps.googleusercontent.com"
                    }
                };


                var payload = await GoogleJsonWebSignature.ValidateAsync(dto.Token, settings);
                var user = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.emailid == payload.Email);

               
                if (user == null)
                {
                    user = new User
                    {
                        Username = payload.Email,
                        emailid = payload.Email,
                        PasswordHash = "ABC",
                        EmployeeId = 0,
                        IsActive = true,
                        RoleId = 2
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }


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

                return Ok(new
                {
                    token,
                    userId = user.UserId,
                    username = user.Username,
                    role = user.Role.RoleName,
                    permissions,
                    email = payload.Email,
                    picture = payload.Picture
                });
                }
                catch (Google.Apis.Auth.InvalidJwtException ex)
                {
                    return Unauthorized(ex.Message);
                }
        }


        [Authorize]
        [HttpGet("Profile")]
        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _context.Users
        //.Include(u => u.Role)  // ← Add this line
        .FirstOrDefault(); 

            if (user == null)
                return NotFound();

            return Ok(new
            {
                user.UserId,
                user.Username,
                user.emailid,
                user.Role,
                user.EmployeeId 
            });
        }

    }
}
