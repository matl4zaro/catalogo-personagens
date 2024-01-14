import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicialComponent } from './pages/inicial.component';

const rotasHome: Routes = [
  {
    path: '', component: InicialComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(rotasHome)],
  exports: [RouterModule]
})
export class HomeRoutes { }
