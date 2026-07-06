using System;
using System.Collections.Generic;

namespace HRMS.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int? UserId { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? DepartmentId { get; set; }

    public int? DesignationId { get; set; }

    public DateOnly? DateOfJoining { get; set; }

    public int? ManagerId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }
}
