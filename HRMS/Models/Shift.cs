using System;
using System.Collections.Generic;

namespace HRMS.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string? ShiftName { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }
}
