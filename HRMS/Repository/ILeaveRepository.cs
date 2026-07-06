using HRMS.DTO;
using HRMS.Models;

namespace HRMS.Repository
{
    public interface ILeaveRepository 
    { 
        Task ApplyLeaveAsync(int employeeId, ApplyLeaveDto dto); 
        Task<IEnumerable<LeaveRequest>> GetPendingAsync(); 
        Task ApproveLeaveAsync(int leaveRequestId, int approverId, bool approve); 
    }
}
