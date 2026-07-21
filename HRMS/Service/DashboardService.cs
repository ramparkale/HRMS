using HRMS.DTO;
using HRMS.Repository;

namespace HRMS.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            return await _repository.GetDashboardAsync();
        }
    }
}
