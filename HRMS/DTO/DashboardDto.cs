namespace HRMS.DTO
{
    public class DashboardDto
    {
        public int PresentToday { get; set; }
        public int AbsentToday { get; set; }
        public int OnLeave { get; set; }
        public int LateCheckIn { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal AttendancePercentage { get; set; }
    }
}
