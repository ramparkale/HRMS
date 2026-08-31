import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AttendanceService } from '../../services/attendance.service';

@Component({
  selector: 'app-monthly-report',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './monthly-report.html',
  //styleUrls: ['./monthly-report.css']
})
export class MonthlyReport {

  private attendanceService = inject(AttendanceService);

  employeeId = Number(localStorage.getItem('employeeId'));

  month = 7;
  year = 2026;

  attendance: any[] = [];

  // search() {

  //   this.attendanceService
  //     .getMonthlyReport(this.employeeId, this.month, this.year)
  //     .subscribe({

  //       next: (res) => {
  //         console.log(res);
  //         this.attendance = res;
  //       },

  //       error: (err) => {
  //         console.error(err);
  //       }

  //     });

  // }
  search() {
  this.attendanceService
  .getMonthlyReport(this.employeeId, this.month, this.year)
  .subscribe({
    next: (blob: any) => {
      const url = window.URL.createObjectURL(blob as Blob);

      const a = document.createElement('a');
      a.href = url;
      a.download = `Attendance_${this.month}_${this.year}.xlsx`;
      a.click();

      window.URL.revokeObjectURL(url);
    },
    error: (err) => {
      console.error(err);
    }
  });
}

}