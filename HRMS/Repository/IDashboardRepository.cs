using HRMS.DTO;

namespace HRMS.Repository
{
    public interface IDashboardRepository
    {
        Task<DashboardDto> GetDashboardAsync();

    }
}
