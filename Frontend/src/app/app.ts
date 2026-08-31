import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Navbar } from './shared/navbar/navbar';
import { Sidebar } from './shared/sidebar/sidebar';
import { Footer } from './shared/footer/footer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    Navbar,
    Sidebar,
    Footer
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
 // protected readonly title = signal('employee-management-system');
}

