namespace HRMS.Repository
{
    using HRMS.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrmsDbContext _context;

        public EmployeeRepository(HrmsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.DepartmentId)
                .Include(e => e.DesignationId)
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }

}
