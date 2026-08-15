import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AutomovelService } from '../../service/automovelService';
import { Automovel } from '../../Models/automovel';

@Component({
  selector: 'app-home-admin',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home-admin.html',
  styleUrl: './home-admin.css'
})
export class HomeAdmin implements OnInit {
  private router = inject(Router);
  private automovelService = inject(AutomovelService);

  // Controla qual seção do Header está ativa (começa em 'automoveis' por padrão)
  public secaoAtiva = signal<'automoveis' | 'clientes' | 'vendas' | 'usuarios'>('automoveis');
  
  // Guarda a lista de automóveis que virá da API
  public automoveis = signal<Automovel[]>([]);
  public nomeUsuario = signal<string | null>('');

  ngOnInit() {
    // Pega o nome do usuário salvo no login para saudar no header
    this.nomeUsuario.set(localStorage.getItem('nomeSGC'));
    this.carregarAutomoveis();
  }

  // Função chamada ao clicar no Header
  mudarSecao(secao: 'automoveis' | 'clientes' | 'vendas' | 'usuarios') {
    this.secaoAtiva.set(secao);
  }

  carregarAutomoveis() {
    // Reutilizando o seu service para buscar os dados
    this.automovelService.getAutomoveis().subscribe({
      next: (dados) => this.automoveis.set(dados),
      error: (err) => console.error('Erro ao carregar automóveis no painel', err)
    });
  }

  // Logout básico
  sair() {
    localStorage.removeItem('tokenSGC');
    localStorage.removeItem('nomeSGC');
    this.router.navigate(['/']);
  }

  // ==== MÉTODOS DE AÇÃO ====
  adicionarAutomovel() {
    console.log('Clicou em Adicionar Automóvel');
  }

  editarAutomovel(carro: Automovel) {
    console.log('Clicou em Editar', carro.idAutomovel);
  }

  excluirAutomovel(carro: Automovel) {
    if(confirm(`Tem certeza que deseja excluir o ${carro.marca} ${carro.modelo}?`)) {
      console.log('Vai chamar a API de exclusão para o ID:', carro.idAutomovel);
    }
  }
}