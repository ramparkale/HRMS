import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../models/login';
import { LoginResponse } from '../models/login-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);

  private apiUrl = "https://localhost:7208/api/Auth";
  router: any;

  login(model: Login): Observable<LoginResponse> {

    return this.http.post<LoginResponse>(
      `${this.apiUrl}/login`,
      model
    );

  }

  logout() {

    localStorage.clear();

    this.router.navigate(['/login']);

  }

  isLoggedIn(): boolean {

    return localStorage.getItem('token') != null;

  }

}