import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // 1. Pegamos o token do LocalStorage
  const token = localStorage.getItem('tokenSGC');

  // 2. Se o token existir, nós clonamos a requisição original e injetamos o cabeçalho de Autorização
  if (token) {
    const reqClonada = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    // Mandamos a requisição modificada (com o token) para o servidor
    return next(reqClonada);
  }

  // Se não tiver token (ex: usuário deslogado na home), manda a requisição normal
  return next(req);
};