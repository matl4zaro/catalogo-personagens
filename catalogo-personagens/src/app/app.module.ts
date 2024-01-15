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

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { LoginDialogComponent } from './shared/components/login-dialog/login-dialog.component';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    // Shared Components
    LoginDialogComponent,
    
  ],
  imports: [
    // Angular
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    CommonModule,
    // Angular Material
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    // Próprios
    AppRoutes,
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
