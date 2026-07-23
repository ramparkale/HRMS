namespace HRMS.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public string Status { get; set; } // Present, Absent, Half Day

        public decimal? WorkingHours { get; set; }
        public decimal? TotalHours { get; set; }
        public Employee Employee { get; set; } 
    }
}
