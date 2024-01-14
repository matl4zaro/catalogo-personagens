import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutes } from './app.routes';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { HomeModule } from './modules/home/home.module';
import { HttpHeadersInterceptor } from './core/interceptors/http-headers.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthService } from './core/auth/auth.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutes,
    BrowserAnimationsModule,
    // Módulos próprios
    CoreModule,
    HomeModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpHeadersInterceptor, multi: true },
    AuthService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
