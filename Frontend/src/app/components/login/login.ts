import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

  username = "";
  password = "";

  private authService = inject(AuthService);
  private router = inject(Router);

  login() {
    const data = {
      username: this.username,
      password: this.password
    };

    this.authService.login(data).subscribe({
      next: (res) => {
        console.log(res);
        localStorage.setItem("token", res.token);
        localStorage.setItem("role", res.role);
        localStorage.setItem("username", res.username);
        localStorage.setItem("employeeId", res.employeeId.toString());

        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        alert("Invalid Username or Password");
        console.log(err);
      }
    });
  }
}