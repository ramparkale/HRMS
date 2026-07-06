namespace HRMS.DTO
{

    public class UpdateHolidayDto
    {
        public int HolidayId { get; set; }

        public string HolidayName { get; set; }

        public DateTime HolidayDate { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
