import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { AutomovelService } from '../../service/automovelService';
import { Automovel } from '../../Models/automovel';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit {
  private automovelService = inject(AutomovelService);
  
  public automoveis = signal<Automovel[]>([]);

  ngOnInit(): void {
    this.carregarAutomoveis();
  }

  carregarAutomoveis(): void {
    this.automovelService.getAutomoveisDeslogados().subscribe({
      next: (dados) => {
        this.automoveis.set(dados);
      },
      error: (erro) => {
        console.error('Erro ao buscar os automóveis', erro);
      }
    });
  }
}