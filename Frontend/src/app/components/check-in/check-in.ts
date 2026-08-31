import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AttendanceService } from '../../services/attendance.service';

@Component({
  selector: 'app-check-in',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './check-in.html',
  styleUrls: ['./check-in.css']
})
export class CheckIn {

  private attendanceService = inject(AttendanceService);

  employeeId =Number(localStorage.getItem('employeeId'));

  checkInTime = new Date();

  checkIn() {

    this.attendanceService.checkIn(this.employeeId).subscribe({

      next: () => {

        alert("Check-In Successful");

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

}