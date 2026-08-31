import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AttendanceService } from '../../services/attendance.service';

@Component({
  selector: 'app-check-out',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './check-out.html',
 // styleUrls: ['./check-out.css']
})
export class CheckOut {

  private attendanceService = inject(AttendanceService);

  employeeId =Number(localStorage.getItem('employeeId'));

  checkOutTime = new Date();

  checkOut() {

    this.attendanceService.checkOut(this.employeeId).subscribe({

      next: (res) => {

        alert("Check-Out Successful");

        console.log(res);

      },

      error: (err) => {

        console.error(err);

        alert(err.error?.message || "Check-Out Failed");

      }

    });

  }

}