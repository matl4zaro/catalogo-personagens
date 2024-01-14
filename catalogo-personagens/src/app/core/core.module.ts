import { NgModule } from '@angular/core';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { RodapeComponent } from './rodape/rodape.component';
import { HttpService } from './http/http.service';
import { AuthService } from './auth/auth.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    HttpClientModule
  ],
  exports: [
    CabecalhoComponent,
    RodapeComponent
  ],
  declarations: [
    CabecalhoComponent,
    RodapeComponent,
  ],
  providers: [
    HttpService,
    AuthService
  ],
})
export class CoreModule { }
