import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const rotasPrincipais: Routes = [
  {
    path: 'home', loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
  },
  {
    path: '', redirectTo: 'home', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(rotasPrincipais, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutes { }
