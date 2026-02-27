import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({ providedIn: 'root' })
export class ApiService {
  private baseUrl = 'http://localhost:5276/api';

  constructor(private http: HttpClient) {}

  // Employees
  getEmployees() : Observable<any[]>{
    return this.http.get<any[]>(`${this.baseUrl}/employees`);
  }

  addEmployee(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/employees`, data);
  }

 // Policies
  getPolicies(): Observable<any> {
    return this.http.get<any[]>(`${this.baseUrl}/policies`);
  }

  // Attendance
  markAttendance(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/attendance`, data);
  }

  // Report
  getDailyReport(date: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/reports/daily-attendance?date=${date}`
    );
  }


}
