import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Login as LoginModel } from '../../Models/login'; 
import { LoginService } from '../../service/loginService';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  private router = inject(Router);
  private loginService = inject(LoginService); 

  public email = signal('');
  public senha = signal('');
  public erro = signal(false);

  fazerLogin() {
    const credenciais: LoginModel = {
      email: this.email(),
      senha: this.senha()
    };

    this.loginService.efetuarLogin(credenciais).subscribe({
      next: (resposta: any) => { 
        this.erro.set(false);
        const meuToken = resposta.token; 
        const nomeUsuario = resposta.nome;
        if (meuToken) {
            localStorage.setItem('tokenSGC', meuToken);
            localStorage.setItem('nomeSGC', nomeUsuario);
        }
        alert(`Login realizado com sucesso! Bem-vindo, ${nomeUsuario}.`);
      },
      error: (erroApi: any) => {
        console.error('Falha na autenticação', erroApi);
        this.erro.set(true);
      }
    });
  }

  voltar() {
    this.router.navigate(['/']);
  }
}