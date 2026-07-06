using System;
using System.Collections.Generic;

namespace HRMS.Models;

public partial class EmployeeShift
{
    public int EmployeeShiftId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ShiftId { get; set; }
}
