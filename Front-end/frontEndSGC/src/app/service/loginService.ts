import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../Models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7281/api/Usuario/Login'; 

  efetuarLogin(credenciais: Login): Observable<any> {
    return this.http.post<any>(this.apiUrl, credenciais);
  }
}