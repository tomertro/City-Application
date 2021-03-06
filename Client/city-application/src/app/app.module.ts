import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CitySearchComponent } from './city-search/city-search.component';
import { HttpClientModule } from '@angular/common/http';
import { CityComponent } from './city/city.component';

@NgModule({
  declarations: [
    AppComponent,
    CitySearchComponent,
    CityComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
