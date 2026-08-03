import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Automovel } from '../Models/automovel';

@Injectable({
  providedIn: 'root'
})
export class AutomovelService {
  private http = inject(HttpClient);
  // Altere a URL abaixo para a rota correta da sua API rodando no Swagger/Kestrel
  private apiUrl = 'https://localhost:7281/api/Automovel/Deslogado?PageNumber=1&PageSize=10'; 

  getAutomoveisDeslogados(): Observable<Automovel[]> {
    return this.http.get<Automovel[]>(this.apiUrl);
  }
}