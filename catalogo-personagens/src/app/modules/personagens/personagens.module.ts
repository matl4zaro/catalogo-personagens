import { NgModule } from '@angular/core';
import { PersonagensRoutes } from './personagens.routes';
import { ListaPersonagensComponent } from './pages/lista-personagens/lista-personagens.component';

//Material
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { PersonagemService } from 'src/app/core/services/personagem.service';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    PersonagensRoutes,
    // Angular
    CommonModule,
    // Material
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
  ],
  exports: [],
  declarations: [
    ListaPersonagensComponent
  ],
  providers: [
    PersonagemService
  ],
})
export class PersonagensModule { }
