import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';

@Component({
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  employees: any[] = [];
  policies: any[] = [];
  error = '';

  form = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    policyId: ['', Validators.required]
  });

  constructor(private api: ApiService, private fb: FormBuilder) {}

  ngOnInit() {
    this.loadEmployees();

  }

  loadEmployees() {
    this.api.getEmployees().subscribe(res => this.employees = res);
    console.log(this.employees);
    
  }

  submit() {
    if (this.form.invalid) return;

    this.api.addEmployee(this.form.value).subscribe({
      next: () => {
        this.form.reset();
        this.error = '';
        this.loadEmployees();
      },
      error: err => this.error = err.error
    });
  }
}


