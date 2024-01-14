import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { EMPTY, Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Injectable()
export class HttpHeadersInterceptor implements HttpInterceptor {

  constructor(private _authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let requestWithHeaders: HttpRequest<any> ;
    requestWithHeaders = req.clone({
      setHeaders: {
        'Content-Type': 'application/json',
        'charset': 'utf-8',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache',
        'Accept': 'application/json'
      }
    });

    if(!this._authService.verificarLogin()){
      return next.handle(requestWithHeaders);
    }

    requestWithHeaders = requestWithHeaders.clone({
      setHeaders: {
        'Authorization': `Bearer ${this._authService.obterToken()}`,
      }
    });

    return next.handle(requestWithHeaders);
  }
}