using HRMS.Models;

namespace HRMS.Service
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
