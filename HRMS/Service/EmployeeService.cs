using HRMS.Models;
using HRMS.Repositories;

namespace HRMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            // Business Validation
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                throw new Exception("First Name is required.");

            if (string.IsNullOrWhiteSpace(employee.EmployeeCode))
                throw new Exception("Employee Code is required.");

            return await _repository.Add(employee);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            return await _repository.Update(employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.Delete(id);
        } 
    }
}