import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { ToastModule } from 'primeng/toast';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from 'src/features/auth/auth.module';
import { BearerAuthInterceptor } from 'src/core/interceptors/bearer-auth.interceptor';
import { ErrorInterceptor } from 'src/core/interceptors/error.interceptor';
import { MatchModule } from 'src/features/match/match.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ToastModule,
    AuthModule,
    MatchModule
  ],
  providers: [
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: BearerAuthInterceptor,
      multi: true
    },
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
