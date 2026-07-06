namespace HRMS.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }

        public string Reason { get; set; }
        public string Status { get; set; } // Pending / Approved / Rejected

        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }

}
