import { Observable, catchError, throwError as observableThrowError } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpService {
  private URL_API: string = environment.URL_API;
  constructor(private http: HttpClient) { }

  protected serviceError(error: HttpResponse<Response> | any) {
    let errMsg = '';
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    return observableThrowError(() => errMsg);
  }
  protected post<TEntrada,TRetorno>(endpoint: string, corpo: TEntrada): Observable<TRetorno> {
    return this.http
      .post<TRetorno>(this.URL_API + endpoint, corpo)
      .pipe(catchError(
          (error: Error) => observableThrowError(() => error)
      ));
  }
  
  protected get<T>(endpoint: string, parametros? : Map<string, string>): Observable<T> {
    let parametrosEmLista : string[] = ['?'];
    parametros?.forEach((value, key) => {
      parametrosEmLista.push(`${key}=${value}`);
    });

    const parametrosEmString = parametros ?
    parametrosEmLista.join('&') :
    '';

    return this.http
      .get<T>(this.URL_API + endpoint + parametrosEmString)
      .pipe(
        catchError(
          (error: Error) => observableThrowError(() => error)
        )
      );
  }

  protected delete(endpoint: string): Observable<boolean> {
    return this.http
      .delete<boolean>(this.URL_API + endpoint)
      .pipe(catchError(
          (error: Error) => observableThrowError(() => error)
      ));
  }

  protected update<T>(endpoint: string, corpo: T): Observable<boolean> {
    return this.http
      .put<boolean>(this.URL_API + endpoint, corpo)
      .pipe(catchError(
          (error: Error) => observableThrowError(() => error)
      ));
  }
}
