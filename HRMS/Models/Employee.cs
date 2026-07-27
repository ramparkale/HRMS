using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    public int? UserId { get; set; }

    [Required(ErrorMessage = "Employee Code is required.")]
    [StringLength(20, MinimumLength = 1,ErrorMessage = "Employee Code must be between 1 and 20 characters.")]
    public string EmployeeCode { get; set; } = string.Empty;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
    [Required(ErrorMessage = "Employee Code is required.")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }    // Navigation Property

    public int? DesignationId { get; set; }
    public Designation Designation { get; set; }    // Navigation Property
    public DateOnly? DateOfJoining { get; set; }

    public int? ManagerId { get; set; }
   // [NotMapped]
    //public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }
}
