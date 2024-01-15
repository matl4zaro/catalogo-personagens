import { DataSource } from '@angular/cdk/collections';
import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable, ReplaySubject, catchError, map, merge, startWith, switchMap } from 'rxjs';
import { PersonagemService } from 'src/app/core/services/personagem.service';
import { ObterPaginaFiltrada } from 'src/app/shared/models/filtro/obter-pagina-filtrada';
import { Personagem } from 'src/app/shared/models/entidades/personagem';

@Component({
  selector: 'personagens-lista',
  templateUrl: 'lista-personagens.component.html'
})

export class ListaPersonagensComponent implements AfterViewInit {
  colunasVisiveis: string [] = ['nome','thumbnailUrl','descricao','personagemId'];
  fonteDados?: PersonagemListaFonteDados;
  carregando: boolean = false;
  filtros: ObterPaginaFiltrada = {
    itensPorPagina: 5,
    pagina: 1,
    termoFiltro: ''
  };
  
  @ViewChild(MatPaginator) paginacao: MatPaginator = new MatPaginator(new MatPaginatorIntl(), ChangeDetectorRef.prototype);
  @ViewChild(MatSort) ordenamento: MatSort = new MatSort();
  
  constructor(private _personagemService: PersonagemService) {
    _personagemService
      .obterPaginaPersonagens(this.filtros)
      .subscribe(
        data => {
          this.fonteDados = new PersonagemListaFonteDados(data.dados);
        }
      );
  }


  ngAfterViewInit() {
    
    // this.fonteDados.paginator = this.paginacao;
    // this.fonteDados.sort = this.ordenamento;

    this.ordenamento.sortChange.subscribe(() => (this.paginacao.pageIndex = 0));

    merge(this.ordenamento.sortChange, this.paginacao.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.carregando = true;
          return this._personagemService
          .obterPaginaPersonagens(this.filtros)
            .pipe(
              // catchError(() => observableOf(null))
            );
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.carregando = false;
          //this.isRateLimitReached = data === null;

          if (data === null) {
            return [];
          }

          // Only refresh the result length if there is new data. In case of rate
          // limit errors, we do not want to reset the paginator to zero, as that
          // would prevent users from re-triggering requests.
          // this.resultsLength = data.;
          return data.dados;
        }),
      )
      .subscribe(
        dados => (this.fonteDados = new PersonagemListaFonteDados(dados))
      );

  }

  aplicaFiltro(evento: Event) : void {
    const filtro = (evento.target as HTMLInputElement).value;
    // this.fonteDados!.filtrar(filtro);

    // if (this.fonteDados.paginator) {
    //   this.fonteDados.paginator.firstPage();
    // }
  }

}

class PersonagemListaFonteDados extends DataSource<Personagem> {
  private _dataStream = new ReplaySubject<Personagem[]>();

  constructor(initialData: Personagem[]) {
    super();
    this.setData(initialData);
  }

  connect(): Observable<Personagem[]> {
    return this._dataStream;
  }

  disconnect() {}

  setData(data: Personagem[]) {
    this._dataStream.next(data);
  }

  filtrar(data: Personagem[], filtro: string) : Personagem[] {
    if (filtro) {
      return data.filter((item) => item.nome.toLowerCase().includes(filtro));
    }
    return data;
  }
}

