import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaPersonagensComponent } from './pages/lista-personagens/lista-personagens.component';

const rotasPersonagens: Routes = [
  {
    path: 'lista', component: ListaPersonagensComponent
  },
  {
    path: '', redirectTo: 'lista', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(rotasPersonagens)],
  exports: [RouterModule]
})
export class PersonagensRoutes { }
