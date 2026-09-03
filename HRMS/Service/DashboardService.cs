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
            try
            {
                return await _repository.GetDashboardAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the dashboard data from DB: {ex.Message}", ex);
            }
        }
    }
}
