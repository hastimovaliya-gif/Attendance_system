import { Component, NgModule } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgModel } from '@angular/forms';

@Component({
 standalone:true,
  imports: [CommonModule,FormsModule],
  templateUrl: './report.component.html'
})
export class ReportComponent {
  date = '';
  report: any[] = [];

  constructor(private api: ApiService) {}

  load() {
    this.api.getDailyReport(this.date).subscribe(res => this.report = res);
  }
}
