import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Automovel } from '../Models/automovel';

@Injectable({
  providedIn: 'root'
})
export class AutomovelService {
  private http = inject(HttpClient);
  private urlGetAutomoveisDesolgados = 'https://localhost:7281/api/Automovel/Deslogado?PageNumber=1&PageSize=10'; 
  private urlGetAutomoveis = 'https://localhost:7281/api/Automovel?PageNumber=1&PageSize=10';

  getAutomoveisDeslogados(): Observable<Automovel[]> {
    return this.http.get<Automovel[]>(this.urlGetAutomoveisDesolgados);
  }
  
  getAutomoveis(): Observable<Automovel[]> {
    return this.http.get<Automovel[]>(this.urlGetAutomoveis);
  }
}