import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterOutlet ,RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CommonModule ,RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'project';
  
   constructor(private router:Router) {}
}
