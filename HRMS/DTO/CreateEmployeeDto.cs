namespace HRMS.DTO
{
    public class CreateEmployeeDto
    {
        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime JoiningDate { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }
    }
}
