import { NgModule } from '@angular/core';
import { InicialComponent } from './pages/inicial.component';
import { HomeRoutes } from './home.routes';

// FORMS
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    HomeRoutes,
    FormsModule,
    MatInputModule,
    MatFormFieldModule
  ],
  exports: [],
  declarations: [
    InicialComponent
  ],
  providers: [],
})
export class HomeModule { }
