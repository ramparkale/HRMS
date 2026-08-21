namespace HRMS.DTO
{
    public class LoginResponseDto
    {
        public string Token { get; set; }

        public int UserId { get; set; }

        public string username { get; set; }

        public string Role { get; set; }

        public int EmployeeId { get; set; } 

        public List<string> Permissions { get; set; }
    }
}
