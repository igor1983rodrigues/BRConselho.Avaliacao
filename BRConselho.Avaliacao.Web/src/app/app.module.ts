import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CalendarModule } from 'primeng/calendar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoadScreenModule } from './shared/loadscreen/loadscreen.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    NgbModule,
    BrowserModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    CalendarModule,
    LoadScreenModule,
    AppRoutingModule
  ],
  // providers: [{
  //   provide: LOCALE_ID,
  //   useValue: 'pt-BR'
  // }],
  bootstrap: [AppComponent]
})
export class AppModule { }
