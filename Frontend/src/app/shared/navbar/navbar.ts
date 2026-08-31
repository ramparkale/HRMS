import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.css']
})
export class Navbar implements OnInit {

  private router = inject(Router);

  username: string = 'Ram';

  ngOnInit(): void {

  console.log(localStorage);

  console.log(localStorage.getItem('username'));

  this.username = localStorage.getItem('username') || 'Ram';

  console.log(this.username);
}

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('username');

    this.router.navigate(['/login']);
  }
}