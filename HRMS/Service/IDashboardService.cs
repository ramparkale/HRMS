using HRMS.DTO;

namespace HRMS.Service
{
    public interface IDashboardService
    {
         Task<DashboardDto> GetDashboardAsync();
         }
}
