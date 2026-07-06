using HRMS.Models;

namespace HRMS.Repository
{
    public interface IEmployeeRepository
    {
        //object Employees { get; }

        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
    } 

}
