import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { UsuarioLogado, UsuarioLogin } from 'src/app/shared/models/entidades/usuario';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription, catchError, pipe } from 'rxjs';
import { Personagem } from 'src/app/shared/models/entidades/personagem';
import { ObterPaginaFiltrada } from 'src/app/shared/models/filtro/obter-pagina-filtrada';
import { PaginaFiltradaDados } from 'src/app/shared/models/pagina-filtrada-dados';

@Injectable()
export class PersonagemService extends HttpService {
  
  logado: boolean = false;
  pesquisaSubscription?: Subscription;
  
  constructor(private _httpClient: HttpClient) {
    super(_httpClient);
  }
  

  public obterPersonagens() : Observable<Personagem[]> {
    return this.get<Personagem[]>(`Personagem/ObterTodos`);
  }

  public obterPaginaPersonagens(filtro: ObterPaginaFiltrada) : Observable<PaginaFiltradaDados<Personagem>> {
    let parametros: Map<string,string> = new Map<string,string>();
    
    if (filtro.termoFiltro != '') {
      parametros.set('termoFiltro', filtro.termoFiltro);
    }
    parametros.set('pagina', filtro.pagina.toString());
    parametros.set('itensPorPagina', filtro.itensPorPagina.toString());
    if (filtro.imagemDisponivel) {
      parametros.set('imagemDisponivel', filtro.imagemDisponivel.toString());
    }
    
    return this.get<any>(`Personagem/ObterPagina`, parametros);
  }

  public obterDetalhesPersonagemId(personagemId: number) : Observable<Personagem> {
    let parametros: Map<string,string> = new Map<string,string>();
    parametros.set('entidadeId', personagemId.toString());

    return this.get<Personagem>(`Personagem/ObterPorId`, parametros);
  }

}

