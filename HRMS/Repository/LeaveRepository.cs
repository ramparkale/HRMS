namespace HRMS.Repository
{
    using HRMS.DTO;
    using HRMS.Models;
    using Microsoft.EntityFrameworkCore;
    public class LeaveRepository : ILeaveRepository 
    { 
        private readonly HrmsDbContext _context; 
        public LeaveRepository(HrmsDbContext context) { _context = context; } 
        public async Task ApplyLeaveAsync(int employeeId, ApplyLeaveDto dto) 
        { 
            int totalDays = (dto.EndDate - dto.StartDate).Days + 1; 
            var balance = await _context.LeaveBalances.FirstOrDefaultAsync(b => b.EmployeeId == employeeId && b.LeaveTypeId == dto.LeaveTypeId); if (balance == null || balance.Balance < totalDays) throw new Exception("Insufficient leave balance"); 
            var request = new LeaveRequest { EmployeeId = employeeId, LeaveTypeId = dto.LeaveTypeId, StartDate = dto.StartDate, EndDate = dto.EndDate, TotalDays = totalDays, Reason = dto.Reason, Status = "Pending" }; _context.LeaveRequests.Add(request); await _context.SaveChangesAsync(); 
        } 
        public async Task<IEnumerable<LeaveRequest>> GetPendingAsync() 
        { 
            return await _context.LeaveRequests.Where(l => l.Status == "Pending").ToListAsync(); 
        } 
        public async Task ApproveLeaveAsync(int leaveRequestId, int approverId, bool approve) 
        { 
            var leave = await _context.LeaveRequests.FirstOrDefaultAsync(l => l.LeaveRequestId == leaveRequestId); 
            if (leave == null) throw new Exception("Leave request not found"); leave.Status = approve ? "Approved" : "Rejected"; leave.ApprovedBy = approverId; leave.ApprovedDate = DateTime.Now; if (approve) { var balance = await _context.LeaveBalances.FirstAsync(b => b.EmployeeId == leave.EmployeeId && b.LeaveTypeId == leave.LeaveTypeId); balance.Balance -= leave.TotalDays; } await _context.SaveChangesAsync(); }
        }

        
}
