namespace HRMS.DTO
{
    public class CreateShiftDto
    {
        public string ShiftName { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
