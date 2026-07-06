namespace HRMS.DTO
{
    public class EmployeeProfileDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public string DepartmentName { get; set; }

        public string DesignationName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime JoiningDate { get; set; }

        public decimal Salary { get; set; }
    }
}
