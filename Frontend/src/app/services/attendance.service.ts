import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Attendance } from '../models/attendance';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  private http = inject(HttpClient);

  private apiUrl = "https://localhost:7208/api/attendance";

  checkIn(employeeId:number): Observable<any>{

    return this.http.post(
      `${this.apiUrl}/CheckIn`,
      { employeeId }
    );

  }

  checkOut(employeeId:number): Observable<any>{

    return this.http.post(
      `${this.apiUrl}/CheckOut`,
      { employeeId }
    );

  }

  getAttendanceHistory(employeeId:number): Observable<Attendance[]>{

    return this.http.get<Attendance[]>(
      `${this.apiUrl}/employee/${employeeId}`
    );

  }

  getTodayAttendance(): Observable<any>{

    return this.http.get(
      `${this.apiUrl}/TodayAttendance`
    );

  }

  getMonthlyReport(employeeId:number,month:number,year:number): Observable<Attendance[]>{

    return this.http.get<Attendance[]>(
      //`${this.apiUrl}/monthly-report/${month}/${year}`
      `${this.apiUrl}/monthly-report?month=${month}&year=${year}`,
    );

  }

  getAttendanceDetails(id:number): Observable<Attendance>{

    return this.http.get<Attendance>(
      `${this.apiUrl}/Details/${id}`
    );

  }

}