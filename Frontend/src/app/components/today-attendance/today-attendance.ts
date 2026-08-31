import { Component } from '@angular/core';

@Component({
  selector: 'app-today-attendance',
  standalone: true,
  templateUrl: './today-attendance.html',
  //styleUrls: ['./today-attendance.css']
})
export class TodayAttendance {

  present = 0;
  absent = 0;

}