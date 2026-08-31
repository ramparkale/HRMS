import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Navbar } from '../shared/navbar/navbar';
import { Sidebar } from '../shared/sidebar/sidebar';
import { Footer } from '../shared/footer/footer';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [
    Navbar,
    Sidebar,
    Footer,
    RouterOutlet
  ],
  templateUrl: './layout.html',
  styleUrls: ['./layout.css']
})
export class Layout {

}