namespace HRMS.Repository
{
    public interface IPayrollRepository
    {
        Task GeneratePayrollAsync(int employeeId, int month, int year);
    }

}
