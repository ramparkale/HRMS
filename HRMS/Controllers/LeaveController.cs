using HRMS.DTO;
using HRMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/leave")]
    [ApiController]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _repository; 
        public LeaveController(ILeaveRepository repository)
        { 
            _repository = repository;
        } 
        // Employee applies leave
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLeave(ApplyLeaveDto dto) 
        { 
            int employeeId = int.Parse(User.FindFirst("UserId").Value); 
            await _repository.ApplyLeaveAsync(employeeId, dto); 
            return Ok("Leave applied successfully"); 
        } 

        // HR/Admin view pending leaves
        [Authorize(Roles = "Admin,HR")] 
        [HttpGet("pending")]
        public async Task<IActionResult> PendingLeaves() 
        { 
            var leaves = await _repository.GetPendingAsync(); 
            return Ok(leaves); 
        } 
        // HR/Admin approve/reject
        [Authorize(Roles = "Admin,HR")]
        [HttpPut("approve/{id}")] 
        public async Task<IActionResult> ApproveLeave(int id, ApproveLeaveDto dto) 
        { 
            int approverId = int.Parse(User.FindFirst("UserId").Value); 
            await _repository.ApproveLeaveAsync(id, approverId, dto.IsApproved); 
            return Ok("Leave updated"); 
        } 
    } 
}

