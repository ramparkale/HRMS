using HRMS.DTO;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly HrmsDbContext _context;

        public DashboardRepository(HrmsDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var today = DateTime.Today;

            var present = await _context.Attendances
                .CountAsync(x => x.AttendanceDate == today && x.Status == "Present");

            var absent = await _context.Attendances
                .CountAsync(x => x.AttendanceDate == today && x.Status == "Absent");

            var leave = await _context.LeaveRequests
                .CountAsync(x =>
                    x.StartDate <= today &&
                    x.EndDate >= today &&
                    x.Status == "Approved");

            var late = await _context.Attendances
                .CountAsync(x =>
                    x.AttendanceDate == today &&
                    x.CheckInTime.Value.TimeOfDay > new TimeSpan(9, 30, 0));

            decimal avgHours = 0;

            var hours = await _context.Attendances
                .Where(x => x.AttendanceDate == today)
                .ToListAsync();

            if (hours.Any())
            {
                avgHours = (decimal)hours
                    .Average(x => x.WorkingHours);
            }

            int totalEmployees = await _context.Employees.CountAsync();

            decimal percentage = totalEmployees == 0
                ? 0
                : Math.Round((decimal)present * 100 / totalEmployees, 2);

            return new DashboardDto
            {
                PresentToday = present,
                AbsentToday = absent,
                OnLeave = leave,
                LateCheckIn = late,
                WorkingHours = avgHours,
                AttendancePercentage = percentage
            };
        }
    }
}
