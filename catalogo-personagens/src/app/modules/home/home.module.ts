import { NgModule } from '@angular/core';
import { InicialComponent } from './pages/inicial.component';
import { HomeRoutes } from './home.routes';

@NgModule({
  imports: [
    HomeRoutes,
  ],
  exports: [],
  declarations: [
    InicialComponent
  ],
  providers: [],
})
export class HomeModule { }
