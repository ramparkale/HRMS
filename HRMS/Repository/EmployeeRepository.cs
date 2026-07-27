using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrmsDbContext _context;

        public EmployeeRepository(HrmsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee?> GetById(int id)
        {
            return await _context.Employees
                //.Include(x => x.DepartmentId)
                //.Include(x => x.DesignationId)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<Employee> Add(Employee employee)
        {
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}