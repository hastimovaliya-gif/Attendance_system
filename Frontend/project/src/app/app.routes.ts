import { Routes } from '@angular/router';
import { EmployeeComponent } from './component/employee/employee.component';
import { AttendanceComponent } from './component/attendance/attendance.component';
import { ReportComponent } from './component/report/report.component';


export const routes: Routes = [
  { path: '', redirectTo: 'employees', pathMatch: 'full' },
  { path: 'employees', component: EmployeeComponent },
  { path: 'attendance', component: AttendanceComponent },
  { path: 'report', component:ReportComponent }
];



