
using HRMS.Models;
using HRMS.Services;

namespace HRMS.Service
{
    public class AttendanceService:IAttendanceService
    {
        private readonly HRMSDbContext _context;

        public AttendanceService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<string> CheckIn(int employeeId)
        {
            try
            {
                var today = DateTime.Today;

                var alreadyExists = _context.Attendances
                    .Any(x => x.EmployeeId == employeeId && x.AttendanceDate == today);

                if (alreadyExists)
                    return "Already checked in today";

                var attendance = new Attendance
                {
                    EmployeeId = employeeId,
                    AttendanceDate = today,
                    CheckIn = DateTime.Now,
                    Status = "Present"
                };

                _context.Attendances.Add(attendance);
                await _context.SaveChangesAsync();

                return "Check-in successful";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during check-in: {ex.Message}");
            }
        }

        public async Task<string> CheckOut(int employeeId)
        {
            try
            {
                var today = DateTime.Today;

                var attendance = _context.Attendances
                    .FirstOrDefault(x => x.EmployeeId == employeeId && x.AttendanceDate == today);

                if (attendance == null)
                    return "Check-in not found";

                if (attendance.CheckOut != null)
                    return "Already checked out";

                attendance.CheckOut = DateTime.Now;

                var hours = (attendance.CheckOut - attendance.CheckIn)?.TotalHours;
                attendance.TotalHours = (decimal?)hours;

                await _context.SaveChangesAsync();

                return "Check-out successful";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during check-out: {ex.Message}");
            }
        }
    }
}
