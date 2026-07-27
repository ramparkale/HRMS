using System;

namespace HRMS.DTOs
{
    public class EmployeeDTO
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int? ManagerId { get; set; }   

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}