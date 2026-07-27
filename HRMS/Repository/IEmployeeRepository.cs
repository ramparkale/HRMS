using HRMS.Models;

namespace HRMS.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee?> GetById(int id);

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(Employee employee);

        Task<bool> Delete(int id);
    }
}