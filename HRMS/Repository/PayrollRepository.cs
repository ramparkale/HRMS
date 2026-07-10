namespace HRMS.Repository
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public class PayrollRepository : IPayrollRepository
    {
        private readonly HrmsDbContext _context;

        public PayrollRepository(HrmsDbContext context)
        {
            _context = context;
        }

        public async Task GeneratePayrollAsync(int employeeId, int month, int year)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_GeneratePayroll @EmployeeId, @Month, @Year",
                new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            );
        }
    }

}
