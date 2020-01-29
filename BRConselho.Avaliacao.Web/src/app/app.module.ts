import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

// the second parameter 'fr' is optional
registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    NgbModule,
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule
  ],
  // providers: [{
  //   provide: LOCALE_ID,
  //   useValue: 'pt-BR'
  // }],
  bootstrap: [AppComponent]
})
export class AppModule { }
