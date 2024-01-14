import { NgModule } from '@angular/core';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { RodapeComponent } from './rodape/rodape.component';

@NgModule({
  imports: [],
  exports: [
    CabecalhoComponent,
    RodapeComponent,
  ],
  declarations: [
    CabecalhoComponent,
    RodapeComponent,
  ],
  providers: [],
})
export class CoreModule { }
