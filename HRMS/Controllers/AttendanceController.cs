using HRMS.DTOs;
using HRMS.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
//using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
            private readonly IConfiguration _configuration;

            public AttendanceController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            private SqlConnection GetConnection()
            {
                return new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                );
            }

        [HttpPost("checkin")]
        public async Task<IActionResult> checkin([FromBody] CheckInDto request)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("USP_EmployeeCheckIn", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", request.EmployeeId);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return Ok(new
            {
                Message = "Check-In Successful"
            });
        }

            // POST: api/attendance/checkout
            [HttpPost("checkout")]
            public async Task<IActionResult> CheckOut([FromBody] CheckOutDto request)
            {
                using (SqlConnection con = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("USP_EmployeeCheckOut", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmployeeId", request.EmployeeId);

                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        await con.CloseAsync();
                    }
                }

                return Ok(new
                {
                    Message = "Check-Out Successful"
                });
            }

            // GET: api/attendance/monthly-report?month=5&year=2026
            [HttpGet("monthly-report")]
            public async Task<IActionResult> MonthlyReport(int month, int year)
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = GetConnection())
                using (SqlCommand cmd = new SqlCommand("USP_MonthlyAttendanceReport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);

                    await con.OpenAsync();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

            using (var workbook = new XLWorkbook())
            {
                // ✅ Automatically adds headers + data
                var worksheet = workbook.Worksheets.Add(dt, "Report");

                // Optional styling
                worksheet.Columns().AdjustToContents();
                //worksheet.RangeUsed().SetAutoFilter();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "MonthlyReport.xlsx"
                    );
                }
            }
            //return null;
        }
            // GET: api/attendance/employee/1
            [HttpGet("employee/{id}")]
            public async Task<IActionResult> GetAttendance(int id)
            {
                    DataTable dt = new DataTable();

                    using (SqlConnection con = GetConnection())
                    {
                        string query = @"
                    SELECT
                        AttendanceId,
                        AttendanceDate,
                        CheckIn,
                        CheckOut,
                        WorkingHours,
                        LateMinutes,
                        OvertimeMinutes,
                        Status
                    FROM Attendance
                    WHERE EmployeeId = @EmployeeId
                    ORDER BY AttendanceDate DESC";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@EmployeeId", id);

                            await con.OpenAsync();

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);

                            await con.CloseAsync();
                        }
                    }
                    
                return Ok(ConvertDataTable(dt));
            }
            private List<Dictionary<string, object>> ConvertDataTable(DataTable dt)
            {
                var data = new List<Dictionary<string, object>>();

                foreach (DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        dict[col.ColumnName] = row[col];
                    }

                    data.Add(dict);
                }

                return data;
            }

        //[HttpPost]
        //public async Task<IActionResult> MarkAttendance(Attendance attendance)
        //{
        //    _configuration.Attendance.Add(attendance);

        //    await _configuration.SaveChangesAsync();

        //    return Ok();
        //}
    
}
}
