import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { UsuarioLogado, UsuarioLogin } from 'src/app/shared/models/usuario';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription, catchError, pipe } from 'rxjs';

@Injectable()
export class AuthService extends HttpService {
  
  logado: boolean = false;
  loginSubscription?: Subscription;
  
  constructor(private _httpClient: HttpClient) {
    super(_httpClient);
  }
  
  public verificarLogin() : boolean {
    this.logado = this._verificaValidadeToken(this._obterJWT());
    return this.logado;
  }

  public logout() : void {
    localStorage.removeItem('token');
    this.logado = false;
  }

  public login(credenciais: UsuarioLogin) : Subscription {
    this.loginSubscription = this.post<UsuarioLogin, UsuarioLogado>('api/seguranca/login', credenciais)
    .subscribe(
      {
        next: data => {
          this._armazenaJWT(data.token);
          this.logado = true;
        },
        error: error => console.log(error)
      });
    
    return this.loginSubscription;
  }

  private _armazenaJWT(tokenJWT: string) : void {
    localStorage.setItem('token', tokenJWT);
    this.loginSubscription?.unsubscribe();
  }
  
  // public obterToken() : string {
  //   return this._obterJWT();
  // }

  obterToken = () => this._obterJWT();

  private _obterJWT() : string {
    return localStorage.getItem('token') ?? "";
  }
  
  private _decodificarJWT(token: string) : any { // tipificar o JWT
    const base64Payload = token.split('.')[1];
    let base64 = base64Payload.replace(/-/g, '+').replace(/_/g, '/');
    let jsonPayload = decodeURIComponent(
      atob(base64)
      .split('')
      .map(
        (c) => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
      ).join('')
    );

    return JSON.parse(jsonPayload);
  }

  private _verificaValidadeToken(token: string): boolean {
    if(token == "")
      return false;
    
    let tokenDecodificado = this._decodificarJWT(token);
    const expiracao = new Date((tokenDecodificado.exp) * 1000);
    const agora = new Date();

    const valido = expiracao > agora;
    return valido;
  }
}
function observableThrowError(arg0: () => Error): any {
  throw new Error('Function not implemented.');
}

