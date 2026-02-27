import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';

@Component({
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './attendance.component.html'
})
export class AttendanceComponent implements OnInit {
  employees: any[] = [];
  msg:any = "";
  form = this.fb.group({
    employeeId: [''],
    attendanceDate: [''],
    status: ['Present'],
    hoursWorked: [0]
  });

  constructor(private api: ApiService, private fb: FormBuilder) {}

  ngOnInit() {
    this.api.getEmployees().subscribe(res => { 
      this.employees = res
    }
    
  
  );
  }

  onStatusChange() {
    if (this.form.value.status === 'Absent') {
      this.form.patchValue({ hoursWorked: 0 });
    }
  }

  submit() {
     this.api.markAttendance(this.form.value).subscribe(
      {
        next: res =>{
          this.msg = "Attendance marked successfully";
          alert(this.msg);
          this.form.reset({status:'Present',hoursWorked:0})
          
        },
        error:err =>{
          this.msg = err.error?.message || err.error || 'Failed to mark attendance due';
          alert(this.msg);
          
        }
      }
     );

 
   
    
  }
}


