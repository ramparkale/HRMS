namespace HRMS.Services
{
    public interface IAttendanceService
    {
        Task<string> CheckIn(int employeeId);
        Task<string> CheckOut(int employeeId);

    }
}
