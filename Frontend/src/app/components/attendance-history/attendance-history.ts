import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AttendanceService } from '../../services/attendance.service';
import { Attendance } from '../../models/attendance';

@Component({
  selector: 'app-attendance-history',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './attendance-history.html'
})
export class AttendanceHistory implements OnInit {

  attendanceList: Attendance[] = [];

  private attendanceService = inject(AttendanceService);

  ngOnInit(): void {
    this.loadAttendance();
  }

  loadAttendance() {
    this.attendanceService.getAttendanceHistory(Number(localStorage.getItem('employeeId'))).subscribe({
      next: (response: Attendance[]) => {
        console.log('API Response:', response);
        this.attendanceList = response;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}